using System;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    public class Vallet : IComparable
    {
        private float grn = 1f;
        private float dollar = 1f;
        private float euro = 1f;
        public string user = "";
        public float Grn {
            set
            {
                if (value < 0)
                    value = 0;
                grn = value;
            }
            get => grn;
        }
        public float Dollar {
            set
            {
                if (value < 0)
                    value = 0;
                dollar = value;
            }
            get => dollar;
        }
        public float Euro {
            set
            {
                if (value < 0)
                    value = 0;
                euro = value;
            }
            get => euro;
        }
        public float Monez
        {
            get => grn + dollar * Rate.dollar + Rate.euro * euro;
        }

        public Vallet(float grn, float dollar, float euro, string user)
        {
            Grn = grn;
            Dollar = dollar;
            Euro = euro;
            this.user = user;
        }

        public int CompareTo(object obj)
        {
            Vallet objVallet = obj as Vallet is null ? new Vallet(0, 0, 0, "") : obj as Vallet;

            if (objVallet.Monez > Monez)
                return -1;
            else if(objVallet.Monez < Monez)
                return 1;

            return 0;
        }
        public override string ToString()
        {
            return $"\n{user}'s vallet:" +
                $"\n grn {grn}" +
                $"\n dollar {dollar} - (grn {dollar * Rate.dollar:0.0}) " +
                $"\n euro {euro} - (grn {euro * Rate.euro:0.0}) " +
                $"\n sum {Monez:0.0}";
        }
    }
}
