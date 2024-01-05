namespace Trainmate.Repositories.Entities;

public class User : EntityBase
{ 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        
        //TODO  pendiente encriptar password :ADR
        public string? Password { get; set; }  
        public bool? trainer { get; set; }
        
        //TODO pendiente implementar enum Genre: ADR
        public string? genre  { get; set; }
        public bool? Active { get; set; }

   
}


