using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult ReceivePayment(Payment payment)
        {
           if(payment.Amount>5000)
            {
                return new ErrorResult("Ödeme gerçekleşmedi");
            }
            else
            {
                return new SuccessResult("Ödeme gerçekleşti");
            }
        }
    }
}
