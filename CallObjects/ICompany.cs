using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FnsComposite.CallObjects
{
  public interface ICompany : IPerson
  {
    string CompanyName { get; set; }
    string LocationCode { get; set; }
  }
}
