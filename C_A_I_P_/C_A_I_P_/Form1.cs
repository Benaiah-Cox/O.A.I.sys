using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace C_A_I_P_
{    
    public partial class Form1 : Form
    {
        string Name = "Caip";
        SpeechSynthesizer s = new SpeechSynthesizer();


       

        /// <summary>
        /// CONTROLS SLEEP AND WAKE MODE SO ThAT it Doesnt RECOGNISE UNWANTED COMMANDS
        /// </summary>

        Boolean wake = true;

        Choices list = new Choices();
        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            /// ALWAAYS ADD NEW COMMANDS HERE THIS IS A LIST OF VIABLE COMMANDS KEEP LOWER CASE

            list.Add(new String[] { "hello", "how are you", "What time is it", "What day is it", "I need to search the web","open google","wake up","sleep","caip", "go to sleep"});

            Grammar gr = new Grammar(new GrammarBuilder(list));

          try
            {


                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeachRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }catch { return; }


            
            s.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen, 1);
           
            InitializeComponent(); 
        }

        public void say(String h)
        {
            s.Speak(h);
        }
        /// <summary>
        /// /The following public void rec_SpeachRecognized is the command log you can type new commands and respones 
        /// </summary>
        //ffff
        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;

            say("hello Benaiah I am Caip");

            if (r == "sleep" || r == "go to sleep") wake = false;
            if (wake == false)
            {
                say("let me know is you need further assistance");
            }
            if (r == "wake up" || r == "caip") wake = true;
            if (wake == true)
            {
             
                


                // What You Say (ALWAYS KEEP LOWER CASE)
                if (r == "hello")
                {
                    //RESPONSE THROW BACK (pause)
                    //Say is a command
                    say("Hi");

                }

                // What You Say (ALWAYS KEEP LOWER CASE)
                if (r == "how are you")
                {
                    //RESPONSE THROW BACK (pause)
                    //Say is a command
                    say("I am great always good to be among the living");

                }
                if (r == "What time is it")
                {
                    say(DateTime.Now.ToString("h:mm tt"));
                }
                if (r == "What day is it")
                {
                    say(DateTime.Now.ToString("M/d/yyyy , h: mm tt"));

                }
                if (r == "I need to search the web" || r == "open google")
                {
                    Process.Start("http://google.com");
                }
               
            }
            
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
