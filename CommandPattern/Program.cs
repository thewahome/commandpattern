﻿using System;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator");

          
              
        }
    }

    //This is a helper type created to decide inside reciever
    enum ActionList
    {
        ADD,
        SUBTRACT,
        MULTIPLY
    }

    interface IReciever
    {
        void SetAction(ActionList action);
        int GetResult();
    }
    abstract class ACommand
    {
        protected IReciever reciever_ = null;

        public ACommand(IReciever reciever)
        {
            reciever_ = reciever;
        }

        public abstract int Execute();
    }

    class AddCommand : ACommand
    {
        public AddCommand(IReciever reciever)
            : base(reciever)
        {

        }
        public override int Execute()
        {
            reciever_.SetAction(ActionList.ADD);
            return reciever_.GetResult();
        }
    }

    class SubtractCommand : ACommand
    {
        public SubtractCommand(IReciever reciever)
            : base(reciever)
        {

        }
        public override int Execute()
        {
            reciever_.SetAction(ActionList.SUBTRACT);
            return reciever_.GetResult();
        }
    }

    class MultiplyCommand : ACommand
    {
        public MultiplyCommand(IReciever reciever)
            : base(reciever)
        {

        }
        public override int Execute()
        {
            reciever_.SetAction(ActionList.MULTIPLY);
            return reciever_.GetResult();
        }
    }

    class Calculator : IReciever
    {
        int x_;
        int y_;

        ActionList currentAction;

        public Calculator(int x, int y)
        {
            x_ = x;
            y_ = y;
        }

        #region IReciever Members

        public void SetAction(ActionList action)
        {
            currentAction = action;
        }

        public int GetResult()
        {
            int result;
            if (currentAction == ActionList.ADD)
            {
                result = x_ + y_;

            }
            else if (currentAction == ActionList.MULTIPLY)
            {
                result = x_ * y_;
            }
            else
            {
                result = x_ - y_;
            }
            return result;
        }

        #endregion
    }

    public partial class testForm : Form
    {
        IReciever calculator = null;
        ACommand command = null;
        AddCommand addCmd = null;
        SubtractCommand subCmd = null;
        MultiplyCommand mulCmd = null;

        public testForm()
        {
            InitializeComponent();
        }

        private void testForm_Load(object sender, EventArgs e)
        {
            calculator = new Calculator(20, 10);

            addCmd = new AddCommand(calculator);
            subCmd = new SubtractCommand(calculator);
            mulCmd = new MultiplyCommand(calculator);
        }

        private void radioAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAdd.Checked == true)
            {
                command = addCmd;
            }
            else if (radioSub.Checked == true)
            {
                command = subCmd;
            }
            else if (radioMultiply.Checked == true)
            {
                command = mulCmd;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Result: " + command.Execute().ToString();
        }
    }

}
