using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class Form1 : Form
    {
         
        public class NodoDecision
        {
            
            public string Pregunta { get; }
            public NodoDecision SiguienteSi { get; }
            public NodoDecision SiguienteNo { get; }

            public NodoDecision(string pregunta, NodoDecision siguienteSi = null, NodoDecision siguienteNo = null)
            {
                Pregunta = pregunta;
                SiguienteSi = siguienteSi;
                SiguienteNo = siguienteNo;
            }
        }
        // Define el árbol de decisiones
        NodoDecision arbolDecisiones = new NodoDecision(
    "¿Tiene congestión nasal?",//Pregunta Inicial nivel 1
    new NodoDecision("¿Estornuda con frecuencia?",//SI nivel2
        new NodoDecision("¿Tienes Dolor de garganta?",//SI nivel3
            new NodoDecision("¿Sientes Fiebre?",//SI nivel4
                new NodoDecision("Diagnóstico: Hay una probabilidad de 100% \n que tengas Gripe \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para reducir la fiebre \ny aliviar los síntomas."),//SI nivel5
                new NodoDecision("Diagnóstico: Resfriado Comun \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para aliviar la congestión \ny la tos")),//NO nivel5
 //-----------------------------------------------------------------------------------------------------
            new NodoDecision("¿Sientes presion en los senos nasales?",//SI nivel4
                new NodoDecision("Diagnóstico: Sinositis \n\nTratamiento: \n-analgésicos, \n-descongestionantes, \n*irrigación nasal, \n-humidificadores."),//SI nivel5
                new NodoDecision("Picor en los ojos?", //NO nivel5
                    new NodoDecision("Diagnóstico: Tienes Alergias \n\nTratamiento: \n-antihistamínicos, \n-descongestionantes, \n-evitación del alérgeno. "),//SI nivel6
                    new NodoDecision("Diagnóstico: Resfriado Comun \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para aliviar la congestión \ny la tos")))),//NO nivel6
 //------------------------------------------------------------------------------------------------------
        new NodoDecision("Te ha aparecido Erupciones Cutaneas?",//NO nivel3
            new NodoDecision("Tienes Alergias?"),//si nivel4
            new NodoDecision("Tienes Dolor de Cabeza?",//NO nivel4
               new NodoDecision("Es como un Dolor Facial?",//SI nivel5
                   new NodoDecision("Diagnóstico: Hay una probabilidad de 50% \n que tengas Sinositis \n\nTratamiento: \n-analgésicos, \n-descongestionantes, \n*irrigación nasal, \n-humidificadores. "),//SI nivel6
                   new NodoDecision("Diagnóstico: Tienes Gripe \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para reducir la fiebre \ny aliviar los síntomas")),//No nivel6
//-------------------------------------------------------------------------------------------------------------
               new NodoDecision("Tienes Flemas espesa y verdosa?",//No nivel5
                   new NodoDecision("Tienes tos?",//SI nivel6
                       new NodoDecision("La tos que tienes es persistente?", //SI nivel7
                           new NodoDecision("Diagnóstico: Tienes Bronquitis \n\nTratamiento: \n -Descanso \n -Líquidos \n-Inhaladores broncodilatadores\n -medicamentos para aliviar la tos.  "), //Si nivel8
                           new NodoDecision("Diagnóstico: Hay una probabilidad de 50% que \n tengas Sinositis")),//No nivel8
                       new NodoDecision("Diagnóstico: Hay una probabilidad de 50% que \n tengas Sinositis")),//No nivel7
                   new NodoDecision("Diagnóstico: Tienes Resfriado Comun \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para aliviar la congestión \ny la tos "))))),//NO nivel6
 //-------------------------------------------------------------------------------------------------------
    new NodoDecision("¿Tienes Tos?",//NO-nivel2
        new NodoDecision("¿Esta Tos viene acompañada con \n flemas verdes y espesa?",// Si-nivel 3
            new NodoDecision("¿Sientes un dolor en el pecho \n por tos persistente?",// Si-nivel 4
                new NodoDecision("Diagnóstico: Hay una probabilidad del 60% \n que estes sufriendo Broquitis \n\nTratamiento: \n -Descanso \n -Líquidos \n-Inhaladores broncodilatadores\n -medicamentos para aliviar la tos. "), //Si - nivel 5
                new NodoDecision("Diagnóstico: Hay una probabilidad del 40% \n que estes sufriendo Broquitis")),//No - nivel 5
            new NodoDecision("Tienes Dolor de Garganta?",// No-nivel 4
                new NodoDecision("Tienes alguna \n molestias generales en tu cuerpo?",// Si-nivel 5
                    new NodoDecision("Diagnóstico: Hay una probabilidad del 60% \n que tenga un Refriado comun \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para aliviar la congestión \ny la tos"), // Si-nivel 6
                    new NodoDecision("Diagnóstico: Hay una probabilidad del 40% \n que tenga un Refriado comun")), // No-nivel 6
                new NodoDecision("Diagnóstico: Es posible que tengas una \n Infeccion glandurar"))),//No - nivel 5
//--------------------------------------------------------------------------------------------------------------------------------
        new NodoDecision("Sientes algun Dolor de Garganta?",// Si-nivel 3
           new NodoDecision("¿Tambien Dolor de Cabeza?",// Si-nivel 4
                new NodoDecision("Con Fiebre?",//Si - nivel 5
                    new NodoDecision("Diagnóstico: Hay una probabilidad del 60% \n que estes con Gripe \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para reducir la fiebre \ny aliviar los síntomas"),// Si-nivel 6
                    new NodoDecision("Diagnóstico: Hay una probabilidad del 40% \n que estes con Gripe")), // No-nivel 6
                new NodoDecision("Diagnóstico: Hay una probabilidad del 40% \n que estes con Gripe")),//No - nivel 5
            new NodoDecision("Te han salido Erucciones Cutaneas?",// No-nivel 4
                new NodoDecision("Con Picazon en los ojos?",// Si-nivel 5
                    new NodoDecision("Y tu nariz hace algun tipo de sibilacion?",// Si-nivel 6
                        new NodoDecision("Diagnóstico: Hay una gran posibilidad que tengas\n una fuerte Alergia \n\nTratamiento: \n-antihistamínicos, \n-descongestionantes, \n-evitación del alérgeno."),// Si-nivel 7
                        new NodoDecision("Diagnóstico: Hay una probabilidad del 40% \n que tengas una Alergia\"")), // No-nivel 7
                    new NodoDecision("Diagnóstico: Tienes un leve Alergia a nivel cutaneo")), // No-nivel 6
                new NodoDecision("Diagnóstico: No suficiente Informacion para \nllegar a una dianostigo exacto")))));//No - nivel 5


        public Form1()
        {
            InitializeComponent();
            MostrarPregunta(arbolDecisiones);
        }
        private void MostrarPregunta(NodoDecision nodo)
        {
            label1.Text = nodo.Pregunta;
            // Oculta el botón "No" si no hay una opción de respuesta
            button2.Visible = nodo.SiguienteNo != null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            if (arbolDecisiones.SiguienteSi != null)
            {
                arbolDecisiones = arbolDecisiones.SiguienteSi;
                MostrarPregunta(arbolDecisiones);
            }
            else
            {
                // Muestra el resultado final si no hay más preguntas
                MessageBox.Show("Resultado final: " + arbolDecisiones.Pregunta);
            }
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            if (arbolDecisiones.SiguienteNo != null)
            {
                arbolDecisiones = arbolDecisiones.SiguienteNo;
                MostrarPregunta(arbolDecisiones);
            }
            else
            {
                // Muestra el resultado final si no hay más preguntas
                MessageBox.Show("Resultado final: " + arbolDecisiones.Pregunta);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            arbolDecisiones = new NodoDecision(
  "¿Tiene congestión nasal?",//Pregunta Inicial nivel 1
    new NodoDecision("¿Estornuda con frecuencia?",//SI nivel2
        new NodoDecision("¿Tienes Dolor de garganta?",//SI nivel3
            new NodoDecision("¿Sientes Fiebre?",//SI nivel4
                new NodoDecision("Diagnóstico: Hay una probabilidad de 100% \n que tengas Gripe \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para reducir la fiebre \ny aliviar los síntomas."),//SI nivel5
                new NodoDecision("Diagnóstico: Resfriado Comun \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para aliviar la congestión \ny la tos")),//NO nivel5
                                                                                                                                                                 //-----------------------------------------------------------------------------------------------------
            new NodoDecision("¿Sientes presion en los senos nasales?",//SI nivel4
                new NodoDecision("Diagnóstico: Sinositis \n\nTratamiento: \n-analgésicos, \n-descongestionantes, \n*irrigación nasal, \n-humidificadores."),//SI nivel5
                new NodoDecision("Picor en los ojos?", //NO nivel5
                    new NodoDecision("Diagnóstico: Tienes Alergias \n\nTratamiento: \n-antihistamínicos, \n-descongestionantes, \n-evitación del alérgeno. "),//SI nivel6
                    new NodoDecision("Diagnóstico: Resfriado Comun \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para aliviar la congestión \ny la tos")))),//NO nivel6
                                                                                                                                                                       //------------------------------------------------------------------------------------------------------
        new NodoDecision("Te ha aparecido Erupciones Cutaneas?",//NO nivel3
            new NodoDecision("Tienes Alergias \n\nTratamiento: \n-antihistamínicos, \n-descongestionantes, \n-evitación del alérgeno."),//si nivel4
            new NodoDecision("Tienes Dolor de Cabeza?",//NO nivel4
               new NodoDecision("Es como un Dolor Facial?",//SI nivel5
                   new NodoDecision("Diagnóstico: Hay una probabilidad de 50% \n que tengas Sinositis \n\nTratamiento: \n-analgésicos, \n-descongestionantes, \n*irrigación nasal, \n-humidificadores. "),//SI nivel6
                   new NodoDecision("Diagnóstico: Tienes Gripe \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para reducir la fiebre \ny aliviar los síntomas")),//No nivel6
                                                                                                                                                                           //-------------------------------------------------------------------------------------------------------------
               new NodoDecision("Tienes Flemas espesa y verdosa?",//No nivel5
                   new NodoDecision("Tienes tos?",//SI nivel6
                       new NodoDecision("La tos que tienes es persistente?", //SI nivel7
                           new NodoDecision("Diagnóstico: Tienes Bronquitis \n\nTratamiento: \n -Descanso \n -Líquidos \n-Inhaladores broncodilatadores\n -medicamentos para aliviar la tos.  "), //Si nivel8
                           new NodoDecision("Diagnóstico: Hay una probabilidad de 50% que \n tengas Sinositis")),//No nivel8
                       new NodoDecision("Diagnóstico: Hay una probabilidad de 50% que \n tengas Sinositis")),//No nivel7
                   new NodoDecision("Diagnóstico: Tienes Resfriado Comun \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para aliviar la congestión \ny la tos "))))),//NO nivel6
                                                                                                                                                                               //-------------------------------------------------------------------------------------------------------
    new NodoDecision("¿Tienes Tos?",//NO-nivel2
        new NodoDecision("¿Esta Tos viene acompañada con \n flemas verdes y espesa?",// Si-nivel 3
            new NodoDecision("¿Sientes un dolor en el pecho \n por tos persistente?",// Si-nivel 4
                new NodoDecision("Diagnóstico: Hay una probabilidad del 60% \n que estes sufriendo Broquitis \n\nTratamiento: \n -Descanso \n -Líquidos \n-Inhaladores broncodilatadores\n -medicamentos para aliviar la tos. "), //Si - nivel 5
                new NodoDecision("Diagnóstico: Hay una probabilidad del 40% \n que estes sufriendo Broquitis")),//No - nivel 5
            new NodoDecision("Tienes Dolor de Garganta?",// No-nivel 4
                new NodoDecision("Tienes alguna \n molestias generales en tu cuerpo?",// Si-nivel 5
                    new NodoDecision("Diagnóstico: Hay una probabilidad del 60% \n que tenga un Refriado comun \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para aliviar la congestión \ny la tos"), // Si-nivel 6
                    new NodoDecision("Diagnóstico: Hay una probabilidad del 40% \n que tenga un Refriado comun")), // No-nivel 6
                new NodoDecision("Diagnóstico: Es posible que tengas una \n Infeccion glandurar"))),//No - nivel 5
                                                                                                    //--------------------------------------------------------------------------------------------------------------------------------
        new NodoDecision("Sientes algun Dolor de Garganta?",// Si-nivel 3
           new NodoDecision("¿Tambien Dolor de Cabeza?",// Si-nivel 4
                new NodoDecision("Con Fiebre?",//Si - nivel 5
                    new NodoDecision("Diagnóstico: Hay una probabilidad del 60% \n que estes con Gripe \n\nTratamiento: \n-descanso \n-líquidos \n-medicamentos para reducir la fiebre \ny aliviar los síntomas"),// Si-nivel 6
                    new NodoDecision("Diagnóstico: Hay una probabilidad del 40% \n que estes con Gripe")), // No-nivel 6
                new NodoDecision("Diagnóstico: Hay una probabilidad del 40% \n que estes con Gripe")),//No - nivel 5
            new NodoDecision("Te han salido Erucciones Cutaneas?",// No-nivel 4
                new NodoDecision("Con Picazon en los ojos?",// Si-nivel 5
                    new NodoDecision("Y tu nariz hace algun tipo de sibilacion?",// Si-nivel 6
                        new NodoDecision("Diagnóstico: Hay una gran posibilidad que tengas\n una fuerte Alergia \n\nTratamiento: \n-antihistamínicos, \n-descongestionantes, \n-evitación del alérgeno."),// Si-nivel 7
                        new NodoDecision("Diagnóstico: Hay una probabilidad del 40% \n que tengas una Alergia\"")), // No-nivel 7
                    new NodoDecision("Diagnóstico: Tienes un leve Alergia a nivel cutaneo")), // No-nivel 6
                new NodoDecision("Diagnóstico: No suficiente Informacion para \nllegar a una dianostigo exacto")))));//No - nivel 5
            MostrarPregunta(arbolDecisiones);

        }
    }
}
