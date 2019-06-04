using System.Collections.Generic;
using System.Linq;

namespace LAB5OP
{
    class ArgsParser
    {
        private string[] args;

        public ArgsParser(string[] args)
        {
            this.args = args;
        }

        public string GetDataBaseName()
        {
            return args[0].Substring(5);
        }
        public Cartesian GetCartesian()
        {
            return new Cartesian(float.Parse(args[1].Substring(6)), float.Parse(args[2].Substring(6)));
        }
        public float GetRadius()
        {
            return float.Parse(args[3].Substring(7));
        }
        public List<string>[] GetParameters()
        {
            List<string>[] parametres = new List<string>[args.Length - 4];
            for (int i = 4; i < args.Length; i++)
            {
                parametres[i - 4] = args[i].Substring(args[i].IndexOf('=') + 1).Split(',').ToList();
            }
            return parametres;
        }
    }
}
