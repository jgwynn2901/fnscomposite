using FnsComposite.Interfaces;
namespace FnsComposite.CallObjects
{
    
    public interface IAdjuster: IComposite
    {
        
        string AdjusterName { get; set; }
        
        string Email { get; set; }
        
        string Phone { get; set; }
        
        string Schedule { get; set; }
       
        string Branch { get; set; }
        
        string TimeZone { get; }

        string Primary { get; }
        
        
    }
}

