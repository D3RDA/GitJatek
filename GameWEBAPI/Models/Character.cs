using System.ComponentModel.DataAnnotations;

namespace Game.Models
{
    public class Character
    {
        
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [StringLength(500)]
            public string Class { get; set; }

        [Required]
        public int Dmg { get; set; } = 100;

        public int Hp { get; set; } = 10;

            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
    }