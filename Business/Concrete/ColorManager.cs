using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        } 

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int Id)
        {
            return _colorDal.Get(p => p.Id == Id);
        }

        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine("\nColor added!\n");
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("\nColor updated!\n");
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("\nColor deleted!\n");
        }

    }
}
