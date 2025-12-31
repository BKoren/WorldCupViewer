using System.Drawing;

namespace WorldCup.DataLayer.Models
{    
    public class Player
    {
        private Image playerImg;
        public Image PlayerImg 
        {
            get => (Image)playerImg?.Clone(); 
            set
            {
                playerImg?.Dispose();
                playerImg = null;

                playerImg = value;
            }
        }        
        public string Name { get; set; }
        public int Shirt_Number { get; set; }
        public string Position { get; set; } 
        public bool Captain { get; set; }

        public int Games { get; set; } = 0;
        public int Goals { get; set; } = 0;
        public int Yellow_Cards { get; set; } = 0;
        public bool Is_Favorite { get; set; } = false;
        public string Country { get; set; }
        public string FIFA_Code { get; set; }

        public override string ToString()
        {
            return
                $"Name={Name}\n" +
                $"Captain={Captain}\n" +
                $"Shirt_Number={Shirt_Number}\n" +
                $"Position={Position}\n" +
                $"Country={Country}\n";
        }

        public override bool Equals(object other)
        {
            if (other is Player)
            {
                return
                    this.Name == ((Player)other).Name &&
                    this.Shirt_Number == ((Player)other).Shirt_Number;
            }

            else
                return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17; 
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Shirt_Number.GetHashCode();
                return hash;
            }

        }
    }
}
