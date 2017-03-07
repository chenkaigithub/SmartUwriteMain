using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace BIMTClassLibrary
{
    public partial class frmBibliographyManagement : Form
    {
        private Word.Range range =null;
        private Word.Document document = null;

        public frmBibliographyManagement() {
            InitializeComponent();
        }

        public frmBibliographyManagement(Word.Range p_range )
        {
            range = p_range;
            InitializeComponent();
        }

        public frmBibliographyManagement(Word.Document p_docWord)
        {
            document = p_docWord;
            InitializeComponent();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {

            //CommonFunction.UpdateContext(range,"hahha");
            CommonFunction.UpdateBookMark(document, "hahaha");
            this.Close();
        }
    }
}
