using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemeGenerator.Models;

namespace MemeGenerator.Presenters
{
    public class MemePresenter
    {

        private MemeModel model;
        public MemePresenter()
        {
            model = new MemeModel();
        }

        public MemeModel MemeModel
        {
            get { return model; }
        }

        public void LoadImage()
        {

        }

        public void Generate()
        {

        }

        public void Reset()
        {
            model.ImageFilePath = "";
            model.TopText = "";
        }
    }
}
