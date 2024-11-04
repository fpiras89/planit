using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planit.Domain.Abstractions.Rules;
public interface IBusinessRule
{
    IBusinessRule SetNext(IBusinessRule nextRule);
    Task<bool> ValidateAsync();
}