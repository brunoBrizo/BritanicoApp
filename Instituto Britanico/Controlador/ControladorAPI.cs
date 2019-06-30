using BibliotecaBritanico.Modelo;
using BibliotecaBritanico.Utilidad;
using Instituto_Britanico.Controlador.Controladores;
using Instituto_Britanico.Vistas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto_Britanico.Controlador
{
    public class ControladorAPI
    {
        public List<Grupo> lstGrupos { get; set; }
        public List<Sucursal> lstSucursales { get; set; }
        public List<Materia> lstMaterias { get; set; }
        public List<Funcionario> lstFuncionarios { get; set; }
        public List<Matricula> lstMatriculas { get; set; } //es la matricula que corresponde al año, siempre es la misma


        List<Libro> Libros { get; set; }
        //esta se va, la necesito para testing
        List<Estudiante> Estudiantes { get; set; }

        List<Examen> Examenes { get; set; }
        List<Pago> Pagos { get; set; }
        List<Matricula> Matriculas { get; set; }
        List<MatriculaEstudiante> MatriculasEstudiante { get; set; }

        internal List<Funcionario> GetProfesoresTotal()
        {
            List<Funcionario> lista = new List<Funcionario>();
            foreach (Funcionario f in lstFuncionarios)
            {
                if (f.TipoFuncionario == FuncionarioTipo.Profesor)
                {
                    if (f.Activo) lista.Add(f);
                }
            }
            return lista;
        }

        List<Convenio> Convenios { get; set; }



        public ControladorAPI()
        {
        }

        public async Task CargarListas()
        {
            DateTime InicioDeIngresos = DateTime.Now;
            lstMaterias = await MateriaController.GetAll();
            lstSucursales = await this.GetListaSucursales();
            lstFuncionarios = await this.GetListaFuncionarios();            
            lstGrupos = await this.GetListaGrupos();
            lstMatriculas = await this.GetListaMatriculasByAnio(DateTime.Today.Year);


            Estudiantes = new List<Estudiante>();
            Libros = new List<Libro>();

            Examenes = new List<Examen>();
            Pagos = new List<Pago>();
            Matriculas = new List<Matricula>();
            MatriculasEstudiante = new List<MatriculaEstudiante>();
            Convenios = new List<Convenio>();


            #region ingreso estudiantes

            Estudiantes.Add(new Estudiante() { CI = "16880678", Nombre = "Juan Santana" });
            Estudiantes.Add(new Estudiante() { CI = "17052569", Nombre = "Jorge Lopez" });
            Estudiantes.Add(new Estudiante() { CI = "17079814", Nombre = "Diego Camacho" });
            Estudiantes.Add(new Estudiante() { CI = "17275878", Nombre = "Juan Eiraldi" });
            Estudiantes.Add(new Estudiante() { CI = "17277315", Nombre = "Gustavo Sardi" });
            Estudiantes.Add(new Estudiante() { CI = "17306914", Nombre = "Alfredo Bellagamba" });
            Estudiantes.Add(new Estudiante() { CI = "17399678", Nombre = "Sergio Pilatos" });
            Estudiantes.Add(new Estudiante() { CI = "17447207", Nombre = "Richard Bodeant" });
            Estudiantes.Add(new Estudiante() { CI = "17616612", Nombre = "Martin Perrone" });
            Estudiantes.Add(new Estudiante() { CI = "17743730", Nombre = "Marcelo Olazarri" });
            Estudiantes.Add(new Estudiante() { CI = "17777371", Nombre = "Jorge Bonnet" });
            Estudiantes.Add(new Estudiante() { CI = "17914024", Nombre = "Orosman Perez" });
            Estudiantes.Add(new Estudiante() { CI = "17969370", Nombre = "Gabriel Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "18080094", Nombre = "Miguel Neris" });
            Estudiantes.Add(new Estudiante() { CI = "18276657", Nombre = "Luis Olascoaga" });
            Estudiantes.Add(new Estudiante() { CI = "18302884", Nombre = "Fabian Maidana" });
            Estudiantes.Add(new Estudiante() { CI = "18326438", Nombre = "Alejandro Bauza" });
            Estudiantes.Add(new Estudiante() { CI = "18349969", Nombre = "Silva, Yanko" });
            Estudiantes.Add(new Estudiante() { CI = "18352823", Nombre = "Richard Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "18461034", Nombre = "Dario Kriznic" });
            Estudiantes.Add(new Estudiante() { CI = "18473091", Nombre = "Richard Alonso" });
            Estudiantes.Add(new Estudiante() { CI = "18528731", Nombre = "Carlos Martinez" });
            Estudiantes.Add(new Estudiante() { CI = "18604355", Nombre = "Marcelo Pallares" });
            Estudiantes.Add(new Estudiante() { CI = "18651916", Nombre = "Claudia Gilardini" });
            Estudiantes.Add(new Estudiante() { CI = "18779035", Nombre = "Ana Teles" });
            Estudiantes.Add(new Estudiante() { CI = "18861377", Nombre = "Fabian Garcia" });
            Estudiantes.Add(new Estudiante() { CI = "18863513", Nombre = "Roberto Ortiz" });
            Estudiantes.Add(new Estudiante() { CI = "18863842", Nombre = "Javier Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "19177434", Nombre = "Carlos Granjel" });
            Estudiantes.Add(new Estudiante() { CI = "19178284", Nombre = "Gabriel Battagliese" });
            Estudiantes.Add(new Estudiante() { CI = "19211832", Nombre = "Rodolfo Santos" });
            Estudiantes.Add(new Estudiante() { CI = "19351563", Nombre = "Fernando Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "19411836", Nombre = "Mauricio Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "19566134", Nombre = "Alfredo Gutierrez" });
            Estudiantes.Add(new Estudiante() { CI = "19640249", Nombre = "Javier De Oliveira" });
            Estudiantes.Add(new Estudiante() { CI = "19813042", Nombre = "Alejandro Lopez" });
            Estudiantes.Add(new Estudiante() { CI = "19884417", Nombre = "Julio Viera" });
            Estudiantes.Add(new Estudiante() { CI = "19887481", Nombre = "Monica Guerra" });
            Estudiantes.Add(new Estudiante() { CI = "19917244", Nombre = "Jorge Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "19928752", Nombre = "Marcelo Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "19938090", Nombre = "Gustavo Mendez" });
            Estudiantes.Add(new Estudiante() { CI = "19950696", Nombre = "Andres Alvarez" });
            Estudiantes.Add(new Estudiante() { CI = "17307479", Nombre = "Gerardo Castro" });
            Estudiantes.Add(new Estudiante() { CI = "29231096", Nombre = "Leonardo Sencion" });
            Estudiantes.Add(new Estudiante() { CI = "20011990", Nombre = "Mario Regueiro" });
            Estudiantes.Add(new Estudiante() { CI = "20030588", Nombre = "Juan Tapie" });
            Estudiantes.Add(new Estudiante() { CI = "20064129", Nombre = "Fabian Kalichman" });
            Estudiantes.Add(new Estudiante() { CI = "20105694", Nombre = "José Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "20150047", Nombre = "Mario De Los Santos" });
            Estudiantes.Add(new Estudiante() { CI = "20195544", Nombre = "Hernan Lopez" });
            Estudiantes.Add(new Estudiante() { CI = "20253041", Nombre = "Nicolas Castro" });
            Estudiantes.Add(new Estudiante() { CI = "25042170", Nombre = "Alex Saralegui" });
            Estudiantes.Add(new Estudiante() { CI = "25112270", Nombre = "Pablo Delgado" });
            Estudiantes.Add(new Estudiante() { CI = "25427978", Nombre = "Pablo Buceta" });
            Estudiantes.Add(new Estudiante() { CI = "25512375", Nombre = "Fabian Odera" });
            Estudiantes.Add(new Estudiante() { CI = "25779002", Nombre = "Marcos Conte" });
            Estudiantes.Add(new Estudiante() { CI = "25782314", Nombre = "Falero, Maria Jose" });
            Estudiantes.Add(new Estudiante() { CI = "26128660", Nombre = "Marcelo Bassi" });
            Estudiantes.Add(new Estudiante() { CI = "26885416", Nombre = "Fernando Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "27089661", Nombre = "Luis Albarenga" });
            Estudiantes.Add(new Estudiante() { CI = "27133147", Nombre = "Javier Perez" });
            Estudiantes.Add(new Estudiante() { CI = "27168867", Nombre = "Fernando Cigluitti" });
            Estudiantes.Add(new Estudiante() { CI = "27243471", Nombre = "Richard Nieto" });
            Estudiantes.Add(new Estudiante() { CI = "27402128", Nombre = "Ricardo De Leon" });
            Estudiantes.Add(new Estudiante() { CI = "27612363", Nombre = "Andrea Martinez" });
            Estudiantes.Add(new Estudiante() { CI = "27972505", Nombre = "Nicolas Bonnet" });
            Estudiantes.Add(new Estudiante() { CI = "28071924", Nombre = "Diego Larrosa" });
            Estudiantes.Add(new Estudiante() { CI = "28136388", Nombre = "Tabare Vieira" });
            Estudiantes.Add(new Estudiante() { CI = "28154223", Nombre = "Danny Falfaro" });
            Estudiantes.Add(new Estudiante() { CI = "28208226", Nombre = "Mario Bergara" });
            Estudiantes.Add(new Estudiante() { CI = "28592322", Nombre = "Alejandra Maset" });
            Estudiantes.Add(new Estudiante() { CI = "28916316", Nombre = "Fredy Martinez" });
            Estudiantes.Add(new Estudiante() { CI = "29038642", Nombre = "Guillermo Gazzara" });
            Estudiantes.Add(new Estudiante() { CI = "29057707", Nombre = "Roberto Hanglie" });
            Estudiantes.Add(new Estudiante() { CI = "29060003", Nombre = "Juan Castillo" });
            Estudiantes.Add(new Estudiante() { CI = "29239145", Nombre = "Rosana Alfonso" });
            Estudiantes.Add(new Estudiante() { CI = "29310850", Nombre = "Gustavo Lasarte" });
            Estudiantes.Add(new Estudiante() { CI = "29316199", Nombre = "Hugo Ramos" });
            Estudiantes.Add(new Estudiante() { CI = "29393737", Nombre = "Favio Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "29619329", Nombre = "Diego Pazos" });
            Estudiantes.Add(new Estudiante() { CI = "29636232", Nombre = "Nicolas Raffo" });
            Estudiantes.Add(new Estudiante() { CI = "29827005", Nombre = "Alejandro Vargas" });
            Estudiantes.Add(new Estudiante() { CI = "29905194", Nombre = "Jose Figueroa" });
            Estudiantes.Add(new Estudiante() { CI = "29915181", Nombre = "Ricardo De Lisa" });
            Estudiantes.Add(new Estudiante() { CI = "29952545", Nombre = "Marcelo De Paula" });
            Estudiantes.Add(new Estudiante() { CI = "215218690011", Nombre = "Luis Vazquez" });
            Estudiantes.Add(new Estudiante() { CI = "30155948", Nombre = "Diego Ruiz" });
            Estudiantes.Add(new Estudiante() { CI = "30322480", Nombre = "Pablo Rolfo" });
            Estudiantes.Add(new Estudiante() { CI = "30503589", Nombre = "Fabricio Pastore" });
            Estudiantes.Add(new Estudiante() { CI = "30546038", Nombre = "Daniel Ferrari" });
            Estudiantes.Add(new Estudiante() { CI = "30615974", Nombre = "Alejandro Marchetti" });
            Estudiantes.Add(new Estudiante() { CI = "30721995", Nombre = "Javier Vidal" });
            Estudiantes.Add(new Estudiante() { CI = "30857655", Nombre = "Jessy Santos" });
            Estudiantes.Add(new Estudiante() { CI = "30908098", Nombre = "Alejandro Ferrari" });
            Estudiantes.Add(new Estudiante() { CI = "31100819", Nombre = "Nicolas Pintos" });
            Estudiantes.Add(new Estudiante() { CI = "31209936", Nombre = "Marcelo Ubal" });
            Estudiantes.Add(new Estudiante() { CI = "31234571", Nombre = "Cristian Inthamoussu" });
            Estudiantes.Add(new Estudiante() { CI = "31298393", Nombre = "Waldemar Callejas" });
            Estudiantes.Add(new Estudiante() { CI = "31310264", Nombre = "Marcelo Mas" });
            Estudiantes.Add(new Estudiante() { CI = "31314759", Nombre = "Diego Falla" });
            Estudiantes.Add(new Estudiante() { CI = "31347841", Nombre = "Richard Mello" });
            Estudiantes.Add(new Estudiante() { CI = "31571420", Nombre = "Juan Pablo Zeballos" });
            Estudiantes.Add(new Estudiante() { CI = "31701354", Nombre = "Fabian Diaz" });
            Estudiantes.Add(new Estudiante() { CI = "31708415", Nombre = "Christian Rossi" });
            Estudiantes.Add(new Estudiante() { CI = "31809085", Nombre = "Gonzalo Novoa" });
            Estudiantes.Add(new Estudiante() { CI = "31830185", Nombre = "Milka Moraes" });
            Estudiantes.Add(new Estudiante() { CI = "31878907", Nombre = "Sergio Martinez" });
            Estudiantes.Add(new Estudiante() { CI = "32036247", Nombre = "Jose Santurio" });
            Estudiantes.Add(new Estudiante() { CI = "32134382", Nombre = "Matias LLado" });
            Estudiantes.Add(new Estudiante() { CI = "32139940", Nombre = "Alvaro Silva" });
            Estudiantes.Add(new Estudiante() { CI = "32222838", Nombre = "Adrian Ibarra" });
            Estudiantes.Add(new Estudiante() { CI = "32361446", Nombre = "Richard Fros" });
            Estudiantes.Add(new Estudiante() { CI = "32655934", Nombre = "Jonathan Gimenos" });
            Estudiantes.Add(new Estudiante() { CI = "32719601", Nombre = "Ema Ferreyra" });
            Estudiantes.Add(new Estudiante() { CI = "32764656", Nombre = "Nelson Ayala" });
            Estudiantes.Add(new Estudiante() { CI = "32828812", Nombre = "Andres Cabana" });
            Estudiantes.Add(new Estudiante() { CI = "32829333", Nombre = "Daniel Luz" });
            Estudiantes.Add(new Estudiante() { CI = "32929874", Nombre = "Nicolas Iturrioz" });
            Estudiantes.Add(new Estudiante() { CI = "33055400", Nombre = "Ricardo Figueroa" });
            Estudiantes.Add(new Estudiante() { CI = "33128762", Nombre = "Diego Licio" });
            Estudiantes.Add(new Estudiante() { CI = "33189275", Nombre = "Fabian Garcia" });
            Estudiantes.Add(new Estudiante() { CI = "33333850", Nombre = "Graciela Sanechez" });
            Estudiantes.Add(new Estudiante() { CI = "33418298", Nombre = "Ana Maria Ramirez" });
            Estudiantes.Add(new Estudiante() { CI = "33649427", Nombre = "Fabian Perez" });
            Estudiantes.Add(new Estudiante() { CI = "33753199", Nombre = "Daniel Salmini" });
            Estudiantes.Add(new Estudiante() { CI = "33945449", Nombre = "Federico Sardella" });
            Estudiantes.Add(new Estudiante() { CI = "34072223", Nombre = "Homero Manzi" });
            Estudiantes.Add(new Estudiante() { CI = "34092229", Nombre = "Fernando Hernandez" });
            Estudiantes.Add(new Estudiante() { CI = "34252732", Nombre = "Mario Castillo" });

            Estudiantes.Add(new Estudiante() { CI = "41706904", Nombre = "Andres Archond" });
            Estudiantes.Add(new Estudiante() { CI = "41880401", Nombre = "Pablo Medero" });
            Estudiantes.Add(new Estudiante() { CI = "41950589", Nombre = "Fernando Mila" });
            Estudiantes.Add(new Estudiante() { CI = "41962580", Nombre = "Maximiliano Barrios" });
            Estudiantes.Add(new Estudiante() { CI = "41987893", Nombre = "Jhon Techera" });
            Estudiantes.Add(new Estudiante() { CI = "41999612", Nombre = "Gustavo Ferreira" });
            Estudiantes.Add(new Estudiante() { CI = "42055849", Nombre = "Mathias Nuñez" });
            Estudiantes.Add(new Estudiante() { CI = "42249915", Nombre = "Gerardo Cabrera" });
            Estudiantes.Add(new Estudiante() { CI = "42272693", Nombre = "Sandra Viera" });
            Estudiantes.Add(new Estudiante() { CI = "42312039", Nombre = "Victor Silva" });
            Estudiantes.Add(new Estudiante() { CI = "42350384", Nombre = "Raul Vidal" });
            Estudiantes.Add(new Estudiante() { CI = "42374295", Nombre = "Walter Sosa" });
            Estudiantes.Add(new Estudiante() { CI = "42411883", Nombre = "Luis Gago" });
            Estudiantes.Add(new Estudiante() { CI = "42454655", Nombre = "Fernando Ferrero" });
            Estudiantes.Add(new Estudiante() { CI = "42475752", Nombre = "Spartaco Silva" });
            Estudiantes.Add(new Estudiante() { CI = "42496207", Nombre = "Jorge Viera" });
            Estudiantes.Add(new Estudiante() { CI = "42522650", Nombre = "German Tabeira" });
            Estudiantes.Add(new Estudiante() { CI = "42527569", Nombre = "Marco Misson" });
            Estudiantes.Add(new Estudiante() { CI = "42567602", Nombre = "Matias Presa" });
            Estudiantes.Add(new Estudiante() { CI = "42668238", Nombre = "Eder Viera" });
            Estudiantes.Add(new Estudiante() { CI = "42668692", Nombre = "Viviana Tregarthen" });
            Estudiantes.Add(new Estudiante() { CI = "42747898", Nombre = "Federico Benitez" });
            Estudiantes.Add(new Estudiante() { CI = "42763763", Nombre = "Juan Martinez" });
            Estudiantes.Add(new Estudiante() { CI = "42778136", Nombre = "Marcelo Dos Santos" });
            Estudiantes.Add(new Estudiante() { CI = "42962779", Nombre = "Francisco Bandera" });
            Estudiantes.Add(new Estudiante() { CI = "42962804", Nombre = "Martin Conti" });
            Estudiantes.Add(new Estudiante() { CI = "43073854", Nombre = "Luciano Almenares" });
            Estudiantes.Add(new Estudiante() { CI = "43133531", Nombre = "Alejandro Cardozo" });
            Estudiantes.Add(new Estudiante() { CI = "43143396", Nombre = "Edinson Rosa" });
            Estudiantes.Add(new Estudiante() { CI = "43179264", Nombre = "Natalia Feippe" });
            Estudiantes.Add(new Estudiante() { CI = "43366291", Nombre = "Renzo Mayer" });
            Estudiantes.Add(new Estudiante() { CI = "43381407", Nombre = "Omar Ferreira" });
            Estudiantes.Add(new Estudiante() { CI = "43439070", Nombre = "William Da Cunha" });
            Estudiantes.Add(new Estudiante() { CI = "43597232", Nombre = "Daniel Burmida" });
            Estudiantes.Add(new Estudiante() { CI = "43618626", Nombre = "Federico Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "43682043", Nombre = "Matias Villarreal" });
            Estudiantes.Add(new Estudiante() { CI = "43822221", Nombre = "Mathias Alachio" });
            Estudiantes.Add(new Estudiante() { CI = "43885152", Nombre = "Rodrigo Dumpierrez" });
            Estudiantes.Add(new Estudiante() { CI = "44009660", Nombre = "Felipe Zarate" });
            Estudiantes.Add(new Estudiante() { CI = "44065929", Nombre = "Gerardo Rasines" });
            Estudiantes.Add(new Estudiante() { CI = "44069583", Nombre = "Lorena Berriel" });
            Estudiantes.Add(new Estudiante() { CI = "44077566", Nombre = "Alberto Zonca" });
            Estudiantes.Add(new Estudiante() { CI = "44252774", Nombre = "Ignacio Guadalupe" });
            Estudiantes.Add(new Estudiante() { CI = "44254653", Nombre = "Christian Zelich" });
            Estudiantes.Add(new Estudiante() { CI = "44341967", Nombre = "Javier Martinez" });
            Estudiantes.Add(new Estudiante() { CI = "44467624", Nombre = "Oscar Garcia" });
            Estudiantes.Add(new Estudiante() { CI = "44475469", Nombre = "Sebastian Alvarez" });
            Estudiantes.Add(new Estudiante() { CI = "44537912", Nombre = "Angelo Modena" });
            Estudiantes.Add(new Estudiante() { CI = "44592073", Nombre = "Giancarlo Tecco" });
            Estudiantes.Add(new Estudiante() { CI = "44653259", Nombre = "Maria Noel Yague" });
            Estudiantes.Add(new Estudiante() { CI = "44723177", Nombre = "Carol Tavarez" });
            Estudiantes.Add(new Estudiante() { CI = "44823931", Nombre = "Matias Gioscio" });
            Estudiantes.Add(new Estudiante() { CI = "44846161", Nombre = "Jonathan Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "44897621", Nombre = "Eugenia Ruibal" });
            Estudiantes.Add(new Estudiante() { CI = "44905242", Nombre = "Andres Ortiz" });
            Estudiantes.Add(new Estudiante() { CI = "44913037", Nombre = "Leandro Soria" });
            Estudiantes.Add(new Estudiante() { CI = "45010232", Nombre = "Washington Reyes" });
            Estudiantes.Add(new Estudiante() { CI = "45074305", Nombre = "Orlando Nicoliello" });
            Estudiantes.Add(new Estudiante() { CI = "45145095", Nombre = "Jorge Martinez" });
            Estudiantes.Add(new Estudiante() { CI = "45288110", Nombre = "Natalia Salomon" });
            Estudiantes.Add(new Estudiante() { CI = "45390511", Nombre = "Matias Sirio" });
            Estudiantes.Add(new Estudiante() { CI = "45425136", Nombre = "Martin Marquez" });
            Estudiantes.Add(new Estudiante() { CI = "45559359", Nombre = "Diego Brianza" });
            Estudiantes.Add(new Estudiante() { CI = "45572294", Nombre = "Santiago Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "45585766", Nombre = "Sebastian Ferreyra" });
            Estudiantes.Add(new Estudiante() { CI = "45620798", Nombre = "Paula Ferreira" });
            Estudiantes.Add(new Estudiante() { CI = "45735345", Nombre = "Jorge García Aicardo" });
            Estudiantes.Add(new Estudiante() { CI = "45735602", Nombre = "Juan Pablo Poggio" });
            Estudiantes.Add(new Estudiante() { CI = "45909932", Nombre = "Santiago Rey" });
            Estudiantes.Add(new Estudiante() { CI = "45954727", Nombre = "Andres Villalba" });
            Estudiantes.Add(new Estudiante() { CI = "45968544", Nombre = "Octavio Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "55093220", Nombre = "Alejandro Tonelli" });
            Estudiantes.Add(new Estudiante() { CI = "55094371", Nombre = "Marcela Marichal" });
            Estudiantes.Add(new Estudiante() { CI = "7691549", Nombre = "Ruben Alvarez" });
            Estudiantes.Add(new Estudiante() { CI = "7896270", Nombre = "Horacio Villar" });

            //int i = 0;
            //int ii = 0;
            //foreach (Estudiante es in Estudiantes)
            //{
            //    es.Email = es.Nombre.Trim() + "@gmail.com";
            //    es.ID = i;
            //    i++;
            //    if (ii == 11) ii = 0;
            //    if (ii == 0)
            //    {
            //        es.Grupo = ga;
            //        ga.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = sa, Matricula = mata, Descuento = 0, FechaHora = new DateTime(2019, 02, 20), Grupo = ga, ID = i, Precio = mata.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 1)
            //    {
            //        es.Grupo = gb;
            //        gb.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = matb.Sucursal, Matricula = mata, Descuento = 0, FechaHora = new DateTime(2019, 02, 21), Grupo = gb, ID = i, Precio = matb.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 2)
            //    {
            //        es.Grupo = gc;
            //        gc.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = matc.Sucursal, Matricula = matc, Descuento = 0, FechaHora = new DateTime(2019, 02, 22), Grupo = gc, ID = i, Precio = matc.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 3)
            //    {
            //        es.Grupo = gd;
            //        gd.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = matd.Sucursal, Matricula = matd, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gc, ID = i, Precio = matd.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 4)
            //    {
            //        es.Grupo = ge;
            //        ge.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = mate.Sucursal, Matricula = mate, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gc, ID = i, Precio = mate.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 5)
            //    {
            //        es.Grupo = gf;
            //        gf.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = mate.Sucursal, Matricula = mate, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gc, ID = i, Precio = mate.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 6)
            //    {
            //        es.Grupo = gg;
            //        gg.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fub, Sucursal = matf.Sucursal, Matricula = matf, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gc, ID = i, Precio = matf.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 7)
            //    {
            //        es.Grupo = gh;
            //        gh.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fub, Sucursal = mata.Sucursal, Matricula = mata, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gd, ID = i, Precio = mata.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 8)
            //    {
            //        es.Grupo = gi;
            //        gi.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fub, Sucursal = mata.Sucursal, Matricula = mata, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = ge, ID = i, Precio = mata.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 9)
            //    {
            //        es.Grupo = gj;
            //        gj.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fub, Sucursal = mata.Sucursal, Matricula = mata, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gf, ID = i, Precio = mata.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 10)
            //    {
            //        es.Grupo = gk;
            //        gk.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fub, Sucursal = matc.Sucursal, Matricula = matc, Descuento = 0, FechaHora = new DateTime(2018, 02, 23), Grupo = gg, ID = i, Precio = matc.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }
            //    if (ii == 11)
            //    {
            //        es.Grupo = gl;
            //        gl.LstEstudiantes.Add(es);
            //        MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fuc, Sucursal = matd.Sucursal, Matricula = matd, Descuento = 0, FechaHora = new DateTime(2018, 03, 10), Grupo = gh, ID = i, Precio = matd.Precio };
            //        MatriculasEstudiante.Add(m);
            //    }

            //    ii++;
            //}
            #endregion

            #region ingreso libros

            //Libro la = new Libro() { ID = 25, Materia = ma, Nombre = "Aprender ingles 101", Precio = 500 };
            //Libro lb = new Libro() { ID = 26, Materia = mb, Nombre = "English For Dummies", Precio = 1500 };
            //Libro lc = new Libro() { ID = 27, Materia = mc, Nombre = "Educando imberbes", Precio = 500 };
            //Libro ld = new Libro() { ID = 28, Materia = md, Nombre = "Sepa la diferencia entre your y your'e", Precio = 500 };
            //Libro le = new Libro() { ID = 29, Materia = me, Nombre = "Throwing horse shit for fun", Precio = 500 };
            //Libro lf = new Libro() { ID = 30, Materia = mf, Nombre = "Nunca voy a aprender", Precio = 500 };
            //Libro lg = new Libro() { ID = 31, Materia = ma, Nombre = "Pa que quiero ingles", Precio = 500 };
            //Libro lh = new Libro() { ID = 32, Materia = ma, Nombre = "Frances en 4 simples pasos", Precio = 500 };

            //Libros.Add(la);
            //Libros.Add(lb);
            //Libros.Add(lc);
            //Libros.Add(ld);
            //Libros.Add(le);
            //Libros.Add(lf);
            //Libros.Add(lg);
            //Libros.Add(lh);
            #endregion

            #region ingreso examenes
            //Examen exa = new Examen() { AnioAsociado = 2019, Grupo = ga, ID = 1, NotaMinima = 80, Precio = 5500, FechaHora = new DateTime(2019, 12, 24) };
            //Examen exb = new Examen() { AnioAsociado = 2019, Grupo = gb, ID = 2, NotaMinima = 60, Precio = 6500, FechaHora = new DateTime(2019, 11, 12) };
            //Examen exc = new Examen() { AnioAsociado = 2019, Grupo = gc, ID = 3, NotaMinima = 60, Precio = 3500, FechaHora = new DateTime(2019, 12, 28) };
            //Examen exd = new Examen() { AnioAsociado = 2019, Grupo = gd, ID = 4, NotaMinima = 70, Precio = 2500, FechaHora = new DateTime(2019, 12, 25) };
            //Examen exe = new Examen() { AnioAsociado = 2019, Grupo = ge, ID = 5, NotaMinima = 80, Precio = 5800, FechaHora = new DateTime(2019, 10, 2) };
            //Examen exf = new Examen() { AnioAsociado = 2019, Grupo = gf, ID = 6, NotaMinima = 70, Precio = 9500, FechaHora = new DateTime(2019, 12, 31) };
            //Examen exg = new Examen() { AnioAsociado = 2018, Grupo = ga, ID = 7, NotaMinima = 76, Precio = 7500, FechaHora = new DateTime(2018, 12, 24) };
            //Examen exh = new Examen() { AnioAsociado = 2018, Grupo = gb, ID = 8, NotaMinima = 65, Precio = 8500, FechaHora = new DateTime(2018, 10, 2) };
            //Examen exi = new Examen() { AnioAsociado = 2018, Grupo = gc, ID = 9, NotaMinima = 70, Precio = 4200, FechaHora = new DateTime(2018, 12, 25) };
            //Examen exj = new Examen() { AnioAsociado = 2018, Grupo = gd, ID = 10, NotaMinima = 70, Precio = 15000, FechaHora = new DateTime(2018, 1, 20) };
            //Examen exk = new Examen() { AnioAsociado = 2018, Grupo = ge, ID = 11, NotaMinima = 80, Precio = 2500, FechaHora = new DateTime(2018, 11, 7) };
            //Examenes.Add(exa);
            //Examenes.Add(exb);
            //Examenes.Add(exc);
            //Examenes.Add(exd);
            //Examenes.Add(exe);
            //Examenes.Add(exf);
            //Examenes.Add(exg);
            //Examenes.Add(exh);
            //Examenes.Add(exj);
            //Examenes.Add(exk);
            #endregion

            #region ingreso de pagos

            //Pago pa = new Pago() { Concepto = "UTE", FechaHora = new DateTime(2019, 02, 24), Funcionario = fua, ID = 1, Monto = 3000, Sucursal = sa };
            //Pago pb = new Pago() { Concepto = "OSE", FechaHora = new DateTime(2019, 02, 25), Funcionario = fua, ID = 2, Monto = 4000, Sucursal = sa };
            //Pago pc = new Pago() { Concepto = "Antel", FechaHora = new DateTime(2019, 02, 20), Funcionario = fub, ID = 3, Monto = 2000, Sucursal = sa };
            //Pago pd = new Pago() { Concepto = "Papel Higienico", FechaHora = new DateTime(2019, 01, 24), Funcionario = fub, ID = 4, Monto = 83000, Sucursal = sa };
            //Pago pe = new Pago() { Concepto = "Sueldos", FechaHora = new DateTime(2019, 02, 10), Funcionario = fub, ID = 5, Monto = 1000, Sucursal = sa };
            //Pago pf = new Pago() { Concepto = "Hojas A4", FechaHora = new DateTime(2019, 01, 15), Funcionario = fub, ID = 6, Monto = 4500, Sucursal = sc };
            //Pago pg = new Pago() { Concepto = "Cafe", FechaHora = new DateTime(2019, 03, 24), Funcionario = fua, ID = 7, Monto = 30000, Sucursal = sc };
            //Pago ph = new Pago() { Concepto = "UTE", FechaHora = new DateTime(2019, 03, 24), Funcionario = fua, ID = 8, Monto = 2000, Sucursal = sc };
            //Pago pi = new Pago() { Concepto = "OSE", FechaHora = new DateTime(2019, 03, 24), Funcionario = fub, ID = 9, Monto = 2100, Sucursal = sc };
            //Pago pj = new Pago() { Concepto = "Alquiler", FechaHora = new DateTime(2019, 04, 2), Funcionario = fub, ID = 10, Monto = 23000, Sucursal = sa };
            //Pago pk = new Pago() { Concepto = "Lapiceras", FechaHora = new DateTime(2019, 04, 24), Funcionario = fuc, ID = 11, Monto = 6000, Sucursal = sb };
            //Pago pl = new Pago() { Concepto = "Mesas", FechaHora = new DateTime(2019, 05, 24), Funcionario = fuc, ID = 12, Monto = 500, Sucursal = sb };
            //Pago pm = new Pago() { Concepto = "Azucar", FechaHora = new DateTime(2019, 05, 24), Funcionario = fud, ID = 13, Monto = 800, Sucursal = sb };
            //Pago pn = new Pago() { Concepto = "Jabon", FechaHora = new DateTime(2019, 05, 24), Funcionario = fud, ID = 14, Monto = 1000, Sucursal = sb };
            //Pago po = new Pago() { Concepto = "Sueldos", FechaHora = new DateTime(2019, 03, 24), Funcionario = fub, ID = 15, Monto = 700, Sucursal = sb };
            //Pago pp = new Pago() { Concepto = "Antel", FechaHora = new DateTime(2019, 01, 24), Funcionario = fub, ID = 16, Monto = 1200, Sucursal = sa };
            //Pago pq = new Pago() { Concepto = "UTE", FechaHora = new DateTime(2018, 01, 24), Funcionario = fub, ID = 17, Monto = 4500, Sucursal = sa };
            //Pago pr = new Pago() { Concepto = "UTE", FechaHora = new DateTime(2018, 04, 24), Funcionario = fub, ID = 18, Monto = 4600, Sucursal = sa };

            //Pagos.Add(pa);
            //Pagos.Add(pb);
            //Pagos.Add(pc);
            //Pagos.Add(pd);
            //Pagos.Add(pe);
            //Pagos.Add(pf);
            //Pagos.Add(pg);
            //Pagos.Add(ph);
            //Pagos.Add(pi);
            //Pagos.Add(pj);
            //Pagos.Add(pk);
            //Pagos.Add(pl);
            //Pagos.Add(pm);
            //Pagos.Add(pn);
            //Pagos.Add(po);
            //Pagos.Add(pp);
            //Pagos.Add(pq);
            //Pagos.Add(pr);

            #endregion

            #region ingreso convenios

            Convenio cona = new Convenio() { Anio = 2019, AsociadoNombre = "Alberto S.A.", ID = 1, Descuento = 10, Nombre = "Albertito 2019" };
            Convenio conb = new Convenio() { Anio = 2019, AsociadoNombre = "Antel", ID = 2, Descuento = 60, Nombre = "informes Antel" };
            Convenio conc = new Convenio() { Anio = 2019, AsociadoNombre = "Cementos De Rivera", ID = 3, Descuento = 15, Nombre = "Secretaria Cementos" };
            Convenio cond = new Convenio() { Anio = 2018, AsociadoNombre = "Antel", ID = 4, Descuento = 10, Nombre = "Directorio Antel" };
            Convenio cone = new Convenio() { Anio = 2018, AsociadoNombre = "Serruchos Deformes S.R.L.", ID = 5, Descuento = 20, Nombre = "El Sierra Alegre" };
            Convenio conf = new Convenio() { Anio = 2017, AsociadoNombre = "El Formon Desafilado S.A.", ID = 6, Descuento = 30, Nombre = "Formones" };
            Convenio cong = new Convenio() { Anio = 2017, AsociadoNombre = "Antel", ID = 7, Descuento = 10, Nombre = "tecnicos Antel" };
            Convenio conh = new Convenio() { Anio = 2016, AsociadoNombre = "La Gubia Loca", ID = 8, Descuento = 20, Nombre = "gubias" };
            Convenio coni = new Convenio() { Anio = 2015, AsociadoNombre = "Cepillos Jaime", ID = 9, Descuento = 10, Nombre = "cepillos" };
            Convenios.Add(cona);
            Convenios.Add(conb);
            Convenios.Add(conc);
            Convenios.Add(cond);
            Convenios.Add(cone);
            Convenios.Add(conf);
            Convenios.Add(cong);
            Convenios.Add(conh);
            Convenios.Add(coni);



            #endregion
            
            #region Orden de listas

            Libros = Libros.OrderBy(l => l.Nombre).ToList();
            Estudiantes = Estudiantes.OrderBy(es => es.Nombre).ToList();
            lstGrupos = lstGrupos.OrderBy(g => g.ID).ToList();
            lstMaterias = lstMaterias.OrderBy(m => m.Nombre).ToList();
            lstFuncionarios = lstFuncionarios.OrderBy(func => func.Nombre).ToList();
            Examenes = Examenes.OrderByDescending(exam => exam.FechaHora).ToList();
            lstSucursales = lstSucursales.OrderBy(sucu => sucu.Nombre).ToList();
            Pagos = Pagos.OrderBy(p => p.FechaHora).ToList();

            #endregion

            DateTime FinDeIngresos = DateTime.Now;
            TimeSpan tiempoTotal = FinDeIngresos - InicioDeIngresos;
            string tiempo = tiempoTotal.TotalMilliseconds + " milisegundos";
        }


        // ---------- Busquedas en listas locales ----------//

        public Materia GetMateriaByID(int id)
        {
            if (id > 0)
            {
                foreach (Materia materia in this.lstMaterias)
                {
                    if (materia.ID.Equals(id))
                    {
                        return materia;
                    }
                }
            }
            return null;
        }

        public Grupo GetGrupoByID(int id, int materiaID)
        {
            if (id > 0 && materiaID > 0)
            {
                foreach (Grupo grupo in this.lstGrupos)
                {
                    if (grupo.ID.Equals(id) && grupo.Materia.ID.Equals(materiaID))
                        return grupo;
                }
            }
            return null;
        }

        public Sucursal GetSucursalByID(int id)
        {
            if (id > 0)
            {
                foreach (Sucursal sucursal in this.lstSucursales)
                {
                    if (sucursal.ID.Equals(id))
                    {
                        return sucursal;
                    }
                }
            }
            return null;
        }

        public Funcionario GetFuncionarioByID(int id)
        {
            if (id > 0)
            {
                foreach (Funcionario funcionario in this.lstFuncionarios)
                {
                    if (funcionario.ID.Equals(id))
                    {
                        return funcionario;
                    }
                }
            }
            return null;
        }

        // ---------- Busquedas en listas locales ----------//



        #region MetodosLlamadaAPI



        #region Materia

        public List<Materia> GetListaMaterias()
        {
            return this.lstMaterias;
        }

        public async Task<Materia> CrearMateria(Materia pMateria)
        {
            try
            {
                pMateria = await MateriaController.Crear(pMateria);
                return pMateria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarMateria(Materia pMateria)
        {
            try
            {
                bool res = await MateriaController.Modificar(pMateria);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarMateria(Materia pMateria)
        {
            try
            {
                bool res = await MateriaController.Eliminar(pMateria);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Convenio


        public async Task<Convenio> GetConvenio(Convenio pConvenio)
        {
            try
            {
                pConvenio = await ConvenioController.Get(pConvenio);
                return pConvenio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Convenio>> GetListaConvenios()
        {
            try
            {
                return await ConvenioController.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Convenio> CrearConvenio(Convenio pConvenio)
        {
            try
            {
                pConvenio = await ConvenioController.Crear(pConvenio);
                return pConvenio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarConvenio(Convenio pConvenio)
        {
            try
            {
                bool res = await ConvenioController.Modificar(pConvenio);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarConvenio(Convenio pConvenio)
        {
            try
            {
                bool res = await ConvenioController.Eliminar(pConvenio);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Email

        public async Task<Email> GetEmail(Email pEmail)
        {
            try
            {
                pEmail = await EmailController.Get(pEmail);
                return pEmail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Email>> GetListaEmails()
        {
            try
            {
                return await EmailController.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Email>> GetListaEmailsEntreFechas(DateTime desde, DateTime hasta)
        {
            try
            {
                return await EmailController.GetEntreFechas(desde, hasta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Email> CrearEmail(Email pEmail)
        {
            try
            {
                pEmail = await EmailController.Crear(pEmail);
                return pEmail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarEmail(Email pEmail)
        {
            try
            {
                bool res = await EmailController.Modificar(pEmail);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarEmail(Email pEmail)
        {
            try
            {
                bool res = await EmailController.Eliminar(pEmail);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        #endregion


        #region Parametro


        public async Task<Parametro> GetParametro(Parametro pParametro)
        {
            try
            {
                pParametro = await ParametroController.Get(pParametro);
                return pParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Parametro>> GetListaParametros()
        {
            try
            {
                return await ParametroController.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Parametro> CrearParametro(Parametro pParametro)
        {
            try
            {
                pParametro = await ParametroController.Crear(pParametro);
                return pParametro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarParametro(Parametro pParametro)
        {
            try
            {
                bool res = await ParametroController.Modificar(pParametro);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarParametro(Parametro pParametro)
        {
            try
            {
                bool res = await ParametroController.Eliminar(pParametro);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Libro


        public async Task<Libro> GetLibro(Libro pLibro)
        {
            try
            {
                pLibro = await LibroController.Get(pLibro);
                pLibro.Materia = this.GetMateriaByID(pLibro.Materia.ID);
                return pLibro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Libro>> GetListaLibros()
        {
            try
            {
                List<Libro> lstLibros = await LibroController.GetAll();
                foreach (Libro libro in lstLibros)
                {
                    libro.Materia = this.GetMateriaByID(libro.Materia.ID);
                }
                return lstLibros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Libro> CrearLibro(Libro pLibro)
        {
            try
            {
                pLibro = await LibroController.Crear(pLibro);
                pLibro.Materia = this.GetMateriaByID(pLibro.Materia.ID);
                return pLibro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarLibro(Libro pLibro)
        {
            try
            {
                bool res = await LibroController.Modificar(pLibro);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarLibro(Libro pLibro)
        {
            try
            {
                bool res = await LibroController.Eliminar(pLibro);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Funcionario


        public async Task<Funcionario> LoginFuncionario(Funcionario pFuncionario)
        {
            try
            {
                pFuncionario = await FuncionarioController.Login(pFuncionario);
                pFuncionario.Sucursal = this.GetSucursalByID(pFuncionario.SucursalID);
                return pFuncionario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Funcionario> GetFuncionario(Funcionario pFuncionario)
        {
            try
            {
                pFuncionario = await FuncionarioController.Get(pFuncionario);
                pFuncionario.Sucursal = this.GetSucursalByID(pFuncionario.SucursalID);
                return pFuncionario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Funcionario>> GetListaFuncionarios()
        {
            try
            {
                List<Funcionario> lstFuncionarios = await FuncionarioController.GetAll();
                foreach (Funcionario funcionario in lstFuncionarios)
                {
                    funcionario.Sucursal = this.GetSucursalByID(funcionario.SucursalID);
                }
                return lstFuncionarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Funcionario> CrearFuncionario(Funcionario pFuncionario)
        {
            try
            {
                pFuncionario = await FuncionarioController.Crear(pFuncionario);
                pFuncionario.Sucursal = this.GetSucursalByID(pFuncionario.SucursalID);
                return pFuncionario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarFuncionario(Funcionario pFuncionario)
        {
            try
            {
                bool res = await FuncionarioController.Modificar(pFuncionario);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarFuncionario(Funcionario pFuncionario)
        {
            try
            {
                bool res = await FuncionarioController.Eliminar(pFuncionario);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #endregion


        #region Matricula


        public async Task<Matricula> GetMatricula(Matricula pMatricula)
        {
            try
            {
                pMatricula = await MatriculaController.Get(pMatricula);
                pMatricula.Sucursal = this.GetSucursalByID(pMatricula.SucursalID);
                return pMatricula;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Matricula>> GetListaMatriculas()
        {
            try
            {
                List<Matricula> lstMatriculas = await MatriculaController.GetAll();
                foreach (Matricula matricula in lstMatriculas)
                {
                    matricula.Sucursal = this.GetSucursalByID(matricula.SucursalID);
                }
                return lstMatriculas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Matricula>> GetListaMatriculasByAnio(int anio)
        {
            try
            {
                List<Matricula> lstMatriculas = await MatriculaController.GetAllByAnio(anio);
                foreach (Matricula matricula in lstMatriculas)
                {
                    matricula.Sucursal = this.GetSucursalByID(matricula.SucursalID);
                }
                return lstMatriculas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task<Matricula> CrearMatricula(Matricula pMatricula)
        {
            try
            {
                pMatricula = await MatriculaController.Crear(pMatricula);
                pMatricula.Sucursal = this.GetSucursalByID(pMatricula.SucursalID);
                return pMatricula;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarMatricula(Matricula pMatricula)
        {
            try
            {
                bool res = await MatriculaController.Modificar(pMatricula);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarMatricula(Matricula pMatricula)
        {
            try
            {
                bool res = await MatriculaController.Eliminar(pMatricula);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Empresa


        public async Task<Empresa> GetEmpresa(Empresa pEmpresa)
        {
            try
            {
                if (pEmpresa.ID > 0)
                    pEmpresa = await EmpresaController.Get(pEmpresa);
                else
                    pEmpresa = await EmpresaController.GetByRut(pEmpresa);
                return pEmpresa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Empresa>> GetListaEmpresas()
        {
            try
            {
                return await EmpresaController.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Empresa> CrearEmpresa(Empresa pEmpresa)
        {
            try
            {
                pEmpresa = await EmpresaController.Crear(pEmpresa);
                return pEmpresa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarEmpresa(Empresa pEmpresa)
        {
            try
            {
                bool res = await EmpresaController.Modificar(pEmpresa);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarEmpresa(Empresa pEmpresa)
        {
            try
            {
                bool res = await EmpresaController.Eliminar(pEmpresa);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Pago


        public async Task<Pago> GetPago(Pago pPago)
        {
            try
            {
                pPago = await PagoController.Get(pPago);
                pPago.Sucursal = this.GetSucursalByID(pPago.SucursalID);
                pPago.Funcionario = this.GetFuncionarioByID(pPago.FuncionarioID);
                return pPago;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Pago>> GetListaPagos()
        {
            try
            {
                List<Pago> lstPagos = await PagoController.GetAll();
                foreach (Pago pago in lstPagos)
                {
                    pago.Sucursal = this.GetSucursalByID(pago.SucursalID);
                    pago.Funcionario = this.GetFuncionarioByID(pago.FuncionarioID);
                }
                return lstPagos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pago> CrearPago(Pago pPago)
        {
            try
            {
                pPago = await PagoController.Crear(pPago);
                pPago.Sucursal = this.GetSucursalByID(pPago.SucursalID);
                pPago.Funcionario = this.GetFuncionarioByID(pPago.FuncionarioID);
                return pPago;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarPago(Pago pPago)
        {
            try
            {
                bool res = await PagoController.Modificar(pPago);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarPago(Pago pPago)
        {
            try
            {
                bool res = await PagoController.Eliminar(pPago);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Sucursal


        public async Task<Sucursal> GetSucursal(Sucursal pSucursal)
        {
            try
            {
                pSucursal = await SucursalController.Get(pSucursal);
                return pSucursal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Sucursal>> GetListaSucursales()
        {
            try
            {
                return await SucursalController.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sucursal> CrearSucursal(Sucursal pSucursal)
        {
            try
            {
                pSucursal = await SucursalController.Crear(pSucursal);
                return pSucursal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarSucursal(Sucursal pSucursal)
        {
            try
            {
                bool res = await SucursalController.Modificar(pSucursal);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarSucursal(Sucursal pSucursal)
        {
            try
            {
                bool res = await SucursalController.Eliminar(pSucursal);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Estudiante


        public async Task<Estudiante> GetEstudiante(Estudiante pEstudiante)
        {
            try
            {
                pEstudiante = await EstudianteController.Get(pEstudiante);
                pEstudiante.Grupo = this.GetGrupoByID(pEstudiante.GrupoID, pEstudiante.MateriaID);
                return pEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Estudiante>> GetListaEstudiantes()
        {
            try
            {
                List<Estudiante> lstEstudiantes = await EstudianteController.GetAll();
                foreach (Estudiante estudiante in lstEstudiantes)
                {
                    estudiante.Grupo = this.GetGrupoByID(estudiante.GrupoID, estudiante.MateriaID);
                }
                return lstEstudiantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Estudiante> CrearEstudiante(Estudiante pEstudiante)
        {
            try
            {
                pEstudiante = await EstudianteController.Crear(pEstudiante);
                pEstudiante.Grupo = this.GetGrupoByID(pEstudiante.GrupoID, pEstudiante.MateriaID);
                return pEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarEstudiante(Estudiante pEstudiante)
        {
            try
            {
                bool res = await EstudianteController.Modificar(pEstudiante);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarEstudiante(Estudiante pEstudiante)
        {
            try
            {
                bool res = await EstudianteController.Eliminar(pEstudiante);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Examen


        public async Task<Examen> GetExamen(Examen pExamen)
        {
            try
            {
                pExamen = await ExamenController.Get(pExamen);
                pExamen.Grupo = this.GetGrupoByID(pExamen.GrupoID, pExamen.MateriaID);
                return pExamen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Examen>> GetListaExamenes()
        {
            try
            {
                List<Examen> lstExamenes = await ExamenController.GetAll();
                foreach (Examen examen in lstExamenes)
                {
                    examen.Grupo = this.GetGrupoByID(examen.GrupoID, examen.MateriaID);
                }
                return lstExamenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Examen> CrearExamen(Examen pExamen)
        {
            try
            {
                pExamen = await ExamenController.Crear(pExamen);
                pExamen.Grupo = this.GetGrupoByID(pExamen.GrupoID, pExamen.MateriaID);
                return pExamen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarExamen(Examen pExamen)
        {
            try
            {
                bool res = await ExamenController.Modificar(pExamen);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarExamen(Examen pExamen)
        {
            try
            {
                bool res = await ExamenController.Eliminar(pExamen);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Grupo


        public async Task<Grupo> GetGrupo(Grupo pGrupo)
        {
            try
            {
                pGrupo = await GrupoController.Get(pGrupo);
                pGrupo.Materia = this.GetMateriaByID(pGrupo.MateriaID);
                pGrupo.Sucursal = this.GetSucursalByID(pGrupo.SucursalID);
                pGrupo.Funcionario = this.GetFuncionarioByID(pGrupo.FuncionarioID);
                return pGrupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Grupo>> GetListaGrupos()
        {
            try
            {
                List<Grupo> lstGrupos = await GrupoController.GetAll();
                foreach (Grupo grupo in lstGrupos)
                {
                    grupo.Materia = this.GetMateriaByID(grupo.MateriaID);
                    grupo.Sucursal = this.GetSucursalByID(grupo.SucursalID);
                    grupo.Funcionario = this.GetFuncionarioByID(grupo.FuncionarioID);
                }
                return lstGrupos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Grupo> CrearGrupo(Grupo pGrupo)
        {
            try
            {
                pGrupo = await GrupoController.Crear(pGrupo);
                pGrupo.Materia = this.GetMateriaByID(pGrupo.MateriaID);
                pGrupo.Sucursal = this.GetSucursalByID(pGrupo.SucursalID);
                pGrupo.Funcionario = this.GetFuncionarioByID(pGrupo.FuncionarioID);
                return pGrupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarGrupo(Grupo pGrupo)
        {
            try
            {
                bool res = await GrupoController.Modificar(pGrupo);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarGrupo(Grupo pGrupo)
        {
            try
            {
                bool res = await GrupoController.Eliminar(pGrupo);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region MatriculaEstudiante


        public async Task<MatriculaEstudiante> GetMatriculaEstudiante(MatriculaEstudiante pMatriculaEstudiante)
        {
            try
            {
                pMatriculaEstudiante = await MatriculaEstudianteController.Get(pMatriculaEstudiante);
                pMatriculaEstudiante.Grupo = this.GetGrupoByID(pMatriculaEstudiante.GrupoID, pMatriculaEstudiante.MateriaID);
                pMatriculaEstudiante.Sucursal = this.GetSucursalByID(pMatriculaEstudiante.SucursalID);
                pMatriculaEstudiante.Funcionario = this.GetFuncionarioByID(pMatriculaEstudiante.FuncionarioID);
                return pMatriculaEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MatriculaEstudiante>> GetListaMatriculaEstudiante()
        {
            try
            {
                List<MatriculaEstudiante> lstMatriculaEstudiante = await MatriculaEstudianteController.GetAll();
                foreach (MatriculaEstudiante matricula in lstMatriculaEstudiante)
                {
                    matricula.Grupo = this.GetGrupoByID(matricula.GrupoID, matricula.MateriaID);
                    matricula.Sucursal = this.GetSucursalByID(matricula.SucursalID);
                    matricula.Funcionario = this.GetFuncionarioByID(matricula.FuncionarioID);
                }
                return lstMatriculaEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MatriculaEstudiante> CrearMatriculaEstudiante(MatriculaEstudiante pMatriculaEstudiante)
        {
            try
            {
                pMatriculaEstudiante = await MatriculaEstudianteController.Crear(pMatriculaEstudiante);
                pMatriculaEstudiante.Grupo = this.GetGrupoByID(pMatriculaEstudiante.GrupoID, pMatriculaEstudiante.MateriaID);
                pMatriculaEstudiante.Sucursal = this.GetSucursalByID(pMatriculaEstudiante.SucursalID);
                pMatriculaEstudiante.Funcionario = this.GetFuncionarioByID(pMatriculaEstudiante.FuncionarioID);
                return pMatriculaEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarMatriculaEstudiante(MatriculaEstudiante pMatriculaEstudiante)
        {
            try
            {
                bool res = await MatriculaEstudianteController.Modificar(pMatriculaEstudiante);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarMatriculaEstudiante(MatriculaEstudiante pMatriculaEstudiante)
        {
            try
            {
                bool res = await MatriculaEstudianteController.Eliminar(pMatriculaEstudiante);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region Mensualidad


        public async Task<Mensualidad> GetMensualidad(Mensualidad pMensualidad)
        {
            try
            {
                pMensualidad = await MensualidadController.Get(pMensualidad);
                pMensualidad.Sucursal = this.GetSucursalByID(pMensualidad.SucursalID);
                pMensualidad.Grupo = this.GetGrupoByID(pMensualidad.GrupoID, pMensualidad.MateriaID);
                pMensualidad.Funcionario = this.GetFuncionarioByID(pMensualidad.FuncionarioID);
                return pMensualidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Mensualidad>> GetListaMensualidades()
        {
            try
            {
                List<Mensualidad> lstMensualidades = await MensualidadController.GetAll();
                foreach (Mensualidad mensualidad in lstMensualidades)
                {
                    mensualidad.Sucursal = this.GetSucursalByID(mensualidad.SucursalID);
                    mensualidad.Grupo = this.GetGrupoByID(mensualidad.GrupoID, mensualidad.MateriaID);
                    mensualidad.Funcionario = this.GetFuncionarioByID(mensualidad.FuncionarioID);
                }
                return lstMensualidades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Mensualidad> CrearMensualidad(Mensualidad pMensualidad)
        {
            try
            {
                pMensualidad = await MensualidadController.Crear(pMensualidad);
                pMensualidad.Sucursal = this.GetSucursalByID(pMensualidad.SucursalID);
                pMensualidad.Grupo = this.GetGrupoByID(pMensualidad.GrupoID, pMensualidad.MateriaID);
                pMensualidad.Funcionario = this.GetFuncionarioByID(pMensualidad.FuncionarioID);
                return pMensualidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarMensualidad(Mensualidad pMensualidad)
        {
            try
            {
                bool res = await MensualidadController.Modificar(pMensualidad);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarMensualidad(Mensualidad pMensualidad)
        {
            try
            {
                bool res = await MensualidadController.Eliminar(pMensualidad);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region VentaLibro


        public async Task<VentaLibro> GetVentaLibro(VentaLibro pVentaLibro)
        {
            try
            {
                pVentaLibro = await VentaLibroController.Get(pVentaLibro);
                return pVentaLibro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<VentaLibro>> GetListaVentaLibro()
        {
            try
            {
                return await VentaLibroController.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<VentaLibro> CrearVentaLibro(VentaLibro pVentaLibro)
        {
            try
            {
                pVentaLibro = await VentaLibroController.Crear(pVentaLibro);
                return pVentaLibro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarVentaLibro(VentaLibro pVentaLibro)
        {
            try
            {
                bool res = await VentaLibroController.Modificar(pVentaLibro);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarVentaLibro(VentaLibro pVentaLibro)
        {
            try
            {
                bool res = await VentaLibroController.Eliminar(pVentaLibro);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region ExamenEstudiante


        public async Task<ExamenEstudiante> GetExamenEstudiante(ExamenEstudiante pExamenEstudiante)
        {
            try
            {
                pExamenEstudiante = await ExamenEstudianteController.Get(pExamenEstudiante);
                pExamenEstudiante.Funcionario = this.GetFuncionarioByID(pExamenEstudiante.FuncionarioID);
                pExamenEstudiante.Examen.Grupo = this.GetGrupoByID(pExamenEstudiante.Examen.GrupoID, pExamenEstudiante.Examen.MateriaID);
                return pExamenEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ExamenEstudiante>> GetListaExamenEstudiante()
        {
            try
            {
                List<ExamenEstudiante> lstExamenEstudiante = await ExamenEstudianteController.GetAll();
                foreach (ExamenEstudiante examenEstudiante in lstExamenEstudiante)
                {
                    examenEstudiante.Funcionario = this.GetFuncionarioByID(examenEstudiante.FuncionarioID);
                    examenEstudiante.Examen.Grupo = this.GetGrupoByID(examenEstudiante.Examen.GrupoID, examenEstudiante.Examen.MateriaID);
                }
                return lstExamenEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExamenEstudiante> CrearExamenEstudiante(ExamenEstudiante pExamenEstudiante)
        {
            try
            {
                pExamenEstudiante = await ExamenEstudianteController.Crear(pExamenEstudiante);
                pExamenEstudiante.Funcionario = this.GetFuncionarioByID(pExamenEstudiante.FuncionarioID);
                pExamenEstudiante.Examen.Grupo = this.GetGrupoByID(pExamenEstudiante.Examen.GrupoID, pExamenEstudiante.Examen.MateriaID);
                return pExamenEstudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarExamenEstudiante(ExamenEstudiante pExamenEstudiante)
        {
            try
            {
                bool res = await ExamenEstudianteController.Modificar(pExamenEstudiante);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarExamenEstudiante(ExamenEstudiante pExamenEstudiante)
        {
            try
            {
                bool res = await ExamenEstudianteController.Eliminar(pExamenEstudiante);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion












        #endregion










        internal bool EliminarLibro(int iD)
        {
            return true;
        }

        internal Libro ModificarLibro(int iD, string titulo, Materia materia, decimal precio, string autor, string editorial)
        {
            return new Libro();
        }

        internal Libro AltaLibro(string titulo, Materia materia, decimal precio, string autor, string editorial)
        {
            return null;
        }

        internal bool EliminarGrupo(int iD)
        {
            bool ame_esta = false;

            return ame_esta;

        }

        internal bool ModificarGrupo(int iD, List<string> listaDias, Sucursal sucursal, Funcionario funcionario, string horaInicio, string horaFin, Materia materia, bool activo, decimal precio)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal Grupo AltaGrupo(List<string> listaDias, Sucursal sucursal, Funcionario funcionario, string horaInicio, string horaFin, Materia materia, bool activo, decimal precio)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Grupo> GetGruposPorNombre(string text)
        {
            List<Grupo> lista = new List<Grupo>();
            foreach (Grupo g in lstGrupos)
            {
                if (g.Nombre.ToLower().Contains(text)) lista.Add(g);
            }
            return lista;
        }

        internal bool EliminarEstudiante(int iD)
        {
            return true;
        }

        internal bool ModificarEstudiante(int iD, string nombre, string cI, string telefono, bool esAlergico, string alergias, string contactoUno, string contactoUnoTel, string contactoDos, string contactoDosTel, string direccion, string correo, DateTime fechaNac, Convenio convenio, bool sino)
        {
            return sino;
        }

        internal bool AltaEstudiante(string nombre, string cI, string telefono, bool esAlergico, string alergias, string contactoUno, string contactoUnoTel, string contactoDos, string contactoDosTel, string direccion, string correo, DateTime fechaNac, Convenio convenio, bool sino)
        {

            return sino;
        }

        internal List<Convenio> GetConveniosTotal()
        {
            return Convenios;
        }

        internal List<Matricula> GetMatriculas()
        {
            return new List<Matricula>();
        }

        internal List<Funcionario> GetFuncionariosActivos()
        {
            List<Funcionario> func = new List<Funcionario>();
            foreach (Funcionario f in lstFuncionarios)
            {
                if (f.Activo)
                {
                    func.Add(f);
                }

            }
            return func;
        }

        internal List<Funcionario> GetFuncionariosNoActivos()
        {
            List<Funcionario> func = new List<Funcionario>();
            foreach (Funcionario f in lstFuncionarios)
            {
                if (!f.Activo)
                {
                    func.Add(f);
                }

            }
            return func;
        }

        internal List<Examen> GetExamenesTotal()
        {
            return Examenes;

        }

        internal List<Pago> GetPagosTotal()
        {
            return Pagos;
        }

        internal List<Grupo> GetGruposTotalb()
        {
            return this.lstGrupos;
        }

        internal List<Funcionario> GetFuncionariosTotal()
        {
            return lstFuncionarios;
        }

        internal List<Pago> GetPagosPorFiltros(string concepto, Sucursal suc, decimal montoMinimo, decimal montoMaximo, DateTime fechaMinima, DateTime fechaMaxima, Funcionario func)
        {
            List<Pago> lista = new List<Pago>();

            var li = Pagos;
            if (concepto != string.Empty)
            {
                li = (from p in li where (p.Concepto).ToLower().Contains(concepto.ToLower()) select p).ToList();
            }
            if (suc != null)
            {
                li = (from p in li where p.Sucursal == suc select p).ToList();
            }
            if (func != null)
            {
                li = (from p in li where p.Funcionario == func select p).ToList();
            }
            if (montoMinimo != 0)
            {
                li = (from p in li where p.Monto >= montoMinimo select p).ToList();
            }
            if (montoMaximo != 0)
            {
                li = (from p in li where p.Monto <= montoMaximo select p).ToList();
            }
            if (fechaMinima != DateTime.MinValue)
            {
                li = (from p in li where p.FechaHora >= fechaMinima select p).ToList();
            }
            if (fechaMaxima != DateTime.MinValue)
            {
                li = (from p in li where p.FechaHora <= fechaMaxima select p).ToList();
            }

            return li;


        }


        internal List<Estudiante> GetEstudiantesPorNombre(string texto)
        {
            List<Estudiante> lista = new List<Estudiante>();
            foreach (Estudiante es in Estudiantes)
            {
                if (es.Nombre.ToLower().Contains(texto.ToLower())) lista.Add(es);
            }
            lista = lista.OrderBy(e => e.Nombre).ToList();
            return lista;
        }


        internal List<Estudiante> GetEstudiantesPorCedula(string cedula)
        {
            List<Estudiante> lista = new List<Estudiante>();
            foreach (Estudiante es in Estudiantes)
            {
                if (es.CI.Contains(cedula))
                {
                    lista.Add(es);
                }
            }
            lista = lista.OrderBy(e => e.Nombre).ToList();
            return lista;
        }

        internal List<Estudiante> GetEstudiantesPorGrupo(Grupo g)
        {
            int i = 0;
            bool encontrado = false;
            List<Estudiante> lista = new List<Estudiante>();
            while (i < lstGrupos.Count && !encontrado)
            {
                if (lstGrupos[i].ID == g.ID)
                {
                    encontrado = true;
                    lista = lstGrupos[i].LstEstudiantes;
                }
                i++;
            }
            lista = lista.OrderBy(e => e.Nombre).ToList();
            return lista;
        }

        internal List<Materia> GetMateriasTotal()
        {
            return lstMaterias;
        }

        internal List<Sucursal> GetSucursalesTotal()
        {
            return lstSucursales;
        }



        internal List<Libro> GetLibrosTotal()
        {
            return Libros;
        }

        internal List<Estudiante> GetEstudiantesTotal()
        {
            return Estudiantes;
        }



    }
}


