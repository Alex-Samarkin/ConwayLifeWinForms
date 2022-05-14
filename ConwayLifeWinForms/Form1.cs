using ConwayLibrary;

namespace ConwayLifeWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TCell c = new TCell();
            TField field = new TField(){Size = 300};
            field.CreateCells();
            //field.RandomFill();
            field.RandomFillSymmetry();

            TField field2 = new TField() { Size = 300 };
            field2.CreateCells();
            field2.NextStep(field);

            TPainter p = new TPainter();
            p.Control = this.panel1;
            p.Field = field2;
            p.Clear();
            p.QDraw();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TCell c = new TCell();
            TField field = new TField() { Size = 250 };
            field.CreateCells();
            //field.RandomFill();
            field.RandomFillSymmetry();

            TField field2 = new TField() { Size = 250 };
            field2.CreateCells();


            for (int i = 0; i < 1000; i++)
            {

                TPainter p = new TPainter();
                p.Control = this.panel1;
                p.Field = field;

                p.Clear();
                p.QDraw();

                field2.NextStep(field);
                (field, field2) = (field2, field);

            }

        }
    }
}