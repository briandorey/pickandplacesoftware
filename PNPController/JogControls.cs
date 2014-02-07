using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNPController
{
    public class JogControls
    {
        // commands related to jog movement
        Mach4.IMyScriptObject Script;


        public void DoJog()
        {

        }


        public void RunJogCommand(string direction, bool goplus, Mach4.IMyScriptObject script)
            
        {
            Script = script;
            //doJOG(direction, goplus);
            var t = new Thread(() => doJOG(direction, goplus));
           t.Start();
           
        }

        private void doJOG(string direction, bool goplus)
        {
            
            double currentpos = 0.0;
           // MessageBox.Show(direction);
           
            switch (direction)
            {
                case "Y":
                     currentpos = Double.Parse(Script.GetParam("YDRO").ToString());
                    break;
                case "X":
                    currentpos = Double.Parse(Script.GetParam("XDRO").ToString());
                    break;
                case "Z":
                    currentpos = Double.Parse(Script.GetParam("ZDRO").ToString());
                    break;
                case "A":
                    currentpos = Double.Parse(Script.GetParam("ADRO").ToString());
                    break;
                case "B":
                    currentpos = Double.Parse(Script.GetParam("BDRO").ToString());
                    break;
                case "C":
                    currentpos = Double.Parse(Script.GetParam("CDRO").ToString());
                    break;
                default:
                    break;
            }
            
           // if (currentpos >= 5)
            //{
                RunMach3Command(Script, "F3000");
                if (goplus)
                {
                    RunMach3Command(Script, "G01 " + direction + "" + (currentpos + 5));
                }
                else
                {
                    RunMach3Command(Script, "G01 " + direction + " " + (currentpos - 5));
                }
                
            //}
        }
        public bool RunMach3Command(Mach4.IMyScriptObject script, string command)
        {
            try
            {
           
            Script.Code(command);
            }
            catch (Exception e ) { MessageBox.Show(e.ToString()); }
            try
            {
                while (script.IsMoving() != 0)
                {
                    Thread.Sleep(10);
                }
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            return true;
        }
    }
}