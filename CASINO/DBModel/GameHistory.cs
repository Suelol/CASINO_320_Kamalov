//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CASINO.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class GameHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int SessionId { get; set; }
        public decimal Bet { get; set; }
        public decimal Result { get; set; }
        public System.DateTime DateTime { get; set; }
    
        public virtual Games Games { get; set; }
        public virtual GameSessions GameSessions { get; set; }
        public virtual Users Users { get; set; }
    }
}
