﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);

        List<OperationClaim> GetClaims(User user);

        User GetByMail(string email);

        IDataResult<UserBasicDto> GetMail(string email);



    }
}
