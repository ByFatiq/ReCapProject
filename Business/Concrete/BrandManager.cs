using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    //İş Kodları - Geçerlilik Şartlarını sağlıyor mu? Örneğin sınavdan 70 almış mı gibi.
    //Validation Doğrulama Kodları;
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand) //Yeni Markayı eklerken minimum max kaç karakter olacağı, şu şuna uymalı ilk harf büyük olmalı gibi.
        {
           


            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAddedSuccess);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeletedSuccess);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandGetAllSuccess);
        }
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdatedSuccess);
        }
    }
}