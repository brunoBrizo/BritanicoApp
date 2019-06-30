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
            CargarListas();
        }

        private async void CargarListas()
        {
            DateTime InicioDeIngresos = DateTime.Now;
            lstMaterias = new List<Materia>();
            Libros = new List<Libro>();
            lstGrupos = new List<Grupo>();
            Estudiantes = new List<Estudiante>();
            lstSucursales = new List<Sucursal>();
            lstFuncionarios = new List<Funcionario>();
            Examenes = new List<Examen>();
            Pagos = new List<Pago>();
            Matriculas = new List<Matricula>();
            MatriculasEstudiante = new List<MatriculaEstudiante>();
            Convenios = new List<Convenio>();


            #region ingreso sucursales
            Sucursal sa = new Sucursal("Centro", "Hermenegildo Riverense 2544", "424", "Hermenegildo@InstitutoBritanicoDeRiveraAlNorteDeUruguay.com", "Flores", "Alberto");
            Sucursal sb = new Sucursal("Rivera Chico", "Nepomuseno Cabrera 3232", "425", "Nepomuseno@InstitutoBritanicoDeRiveraAlNorteDeUruguay.com", "Rivera", "Jacinto");
            Sucursal sc = new Sucursal("Maldonado", "Aristobulo Gimenez 1211", "421", "Aristobuloo@InstitutoBritanicoDeRiveraAlNorteDeUruguay.com", "Rivera", "Florencio");

            lstSucursales.Add(sa);
            lstSucursales.Add(sb);
            lstSucursales.Add(sc);
            #endregion

            #region ingreso de Matriculas
            Matricula mata = new Matricula() { Anio = 2019, Sucursal = sa, FechaHora = new DateTime(2019, 1, 20), ID = 1, Precio = 5000 };
            Matricula matb = new Matricula() { Anio = 2019, Sucursal = sb, FechaHora = new DateTime(2019, 1, 20), ID = 2, Precio = 4000 };
            Matricula matc = new Matricula() { Anio = 2018, Sucursal = sa, FechaHora = new DateTime(2018, 1, 20), ID = 3, Precio = 4000 };
            Matricula matd = new Matricula() { Anio = 2018, Sucursal = sb, FechaHora = new DateTime(2018, 1, 20), ID = 4, Precio = 3000 };
            Matricula mate = new Matricula() { Anio = 2017, Sucursal = sa, FechaHora = new DateTime(2018, 1, 20), ID = 5, Precio = 3000 };
            Matricula matf = new Matricula() { Anio = 2017, Sucursal = sb, FechaHora = new DateTime(2018, 1, 20), ID = 6, Precio = 2000 };
            #endregion

            #region ingreso materias
            Materia ma = new Materia() { ID = 1, Nombre = "Kinder", Sucursal = sa };
            Materia mb = new Materia() { ID = 2, Nombre = "Children 1", Sucursal = sa };
            Materia mc = new Materia() { ID = 3, Nombre = "Children 2", Sucursal = sa };
            Materia md = new Materia() { ID = 4, Nombre = "Pre First Certificate of English", Sucursal = sa };
            Materia me = new Materia() { ID = 5, Nombre = "First Certificate of English", Sucursal = sa };
            Materia mf = new Materia() { ID = 6, Nombre = "Cambridge Advanced English", Sucursal = sa };
            Materia mg = new Materia() { ID = 7, Nombre = "Cambridge Proficiency English", Sucursal = sa };
            Materia mh = new Materia() { ID = 8, Nombre = "J1", Sucursal = sa };
            Materia mi = new Materia() { ID = 9, Nombre = "J2", Sucursal = sa };
            Materia mj = new Materia() { ID = 10, Nombre = "J3", Sucursal = sa };
            Materia mk = new Materia() { ID = 11, Nombre = "J4", Sucursal = sa };
            Materia ml = new Materia() { ID = 12, Nombre = "J5", Sucursal = sa };
            Materia mm = new Materia() { ID = 13, Nombre = "J6", Sucursal = sa };
            Materia mn = new Materia() { ID = 14, Nombre = "Children 2", Sucursal = sb };
            Materia mo = new Materia() { ID = 15, Nombre = "Cambridge Proficiency English", Sucursal = sb };
            Materia mp = new Materia() { ID = 16, Nombre = "Children 1", Sucursal = sb };


            lstMaterias.Add(ma);
            lstMaterias.Add(mb);
            lstMaterias.Add(mc);
            lstMaterias.Add(md);
            lstMaterias.Add(me);
            lstMaterias.Add(mf);
            lstMaterias.Add(mg);
            lstMaterias.Add(mh);
            lstMaterias.Add(mi);
            lstMaterias.Add(mj);
            lstMaterias.Add(mk);
            lstMaterias.Add(ml);
            lstMaterias.Add(mm);
            lstMaterias.Add(mn);
            lstMaterias.Add(mo);
            lstMaterias.Add(mp);

            //this.Materias = await MateriaController.GetAll();



            #endregion

            #region ingreso grupos
            Grupo ga = new Grupo() { ID = 5, Materia = ma, Sucursal = sa };
            Grupo gb = new Grupo() { ID = 6, Materia = mb, Sucursal = sb };
            Grupo gc = new Grupo() { ID = 7, Materia = mc, Sucursal = sc };
            Grupo gd = new Grupo() { ID = 8, Materia = md, Sucursal = sa };
            Grupo ge = new Grupo() { ID = 9, Materia = me, Sucursal = sb };
            Grupo gf = new Grupo() { ID = 10, Materia = mf, Sucursal = sb };
            Grupo gg = new Grupo() { ID = 10, Materia = mg, Sucursal = sb };
            Grupo gh = new Grupo() { ID = 10, Materia = mh, Sucursal = sb };
            Grupo gi = new Grupo() { ID = 10, Materia = mi, Sucursal = sb };
            Grupo gj = new Grupo() { ID = 10, Materia = mj, Sucursal = sb };
            Grupo gk = new Grupo() { ID = 10, Materia = mk, Sucursal = sb };
            Grupo gl = new Grupo() { ID = 10, Materia = ml, Sucursal = sb };
            Grupo gm = new Grupo() { ID = 10, Materia = mm, Sucursal = sb };

            lstGrupos.Add(ga);
            lstGrupos.Add(gb);
            lstGrupos.Add(gc);
            lstGrupos.Add(gd);
            lstGrupos.Add(ge);
            lstGrupos.Add(gf);
            lstGrupos.Add(gg);
            lstGrupos.Add(gh);
            lstGrupos.Add(gi);
            lstGrupos.Add(gj);
            lstGrupos.Add(gk);
            lstGrupos.Add(gl);
            lstGrupos.Add(gm);

            ga.LstEstudiantes = new List<Estudiante>();
            gb.LstEstudiantes = new List<Estudiante>();
            gc.LstEstudiantes = new List<Estudiante>();
            gd.LstEstudiantes = new List<Estudiante>();
            ge.LstEstudiantes = new List<Estudiante>();
            gf.LstEstudiantes = new List<Estudiante>();
            gg.LstEstudiantes = new List<Estudiante>();
            gh.LstEstudiantes = new List<Estudiante>();
            gi.LstEstudiantes = new List<Estudiante>();
            gj.LstEstudiantes = new List<Estudiante>();
            gk.LstEstudiantes = new List<Estudiante>();
            gl.LstEstudiantes = new List<Estudiante>();
            gm.LstEstudiantes = new List<Estudiante>();
            ga.LstDias = new List<GrupoDia>();
            gb.LstDias = new List<GrupoDia>();
            gc.LstDias = new List<GrupoDia>();
            gd.LstDias = new List<GrupoDia>();
            ge.LstDias = new List<GrupoDia>();
            gf.LstDias = new List<GrupoDia>();
            gg.LstDias = new List<GrupoDia>();
            gh.LstDias = new List<GrupoDia>();
            gi.LstDias = new List<GrupoDia>();
            gj.LstDias = new List<GrupoDia>();
            gk.LstDias = new List<GrupoDia>();
            gl.LstDias = new List<GrupoDia>();
            gm.LstDias = new List<GrupoDia>();
            GrupoDia gda = new GrupoDia(1, "Lunes");
            GrupoDia gdb = new GrupoDia(2, "Martes");
            GrupoDia gdc = new GrupoDia(3, "Miercoles");
            GrupoDia gdd = new GrupoDia(4, "Jueves");
            GrupoDia gde = new GrupoDia(5, "Viernes");
            GrupoDia gdf = new GrupoDia(6, "Sabado");
            GrupoDia gdg = new GrupoDia(7, "Domingo");

            ga.LstDias.Add(gda);
            ga.LstDias.Add(gdc);
            ga.HoraInicio = "19:00";
            ga.HoraFin = "22:00";
            gb.LstDias.Add(gdb);
            gb.LstDias.Add(gdd);
            gb.HoraInicio = "19:00";
            gb.HoraFin = "22:00";
            gc.LstDias.Add(gda);
            gc.LstDias.Add(gdc);
            gc.LstDias.Add(gde);
            gc.HoraInicio = "18:00";
            gc.HoraFin = "23:00";
            gd.LstDias.Add(gda);
            gd.LstDias.Add(gdc);
            gd.HoraInicio = "07:00";
            gd.HoraFin = "08:30";
            ge.LstDias.Add(gda);
            ge.LstDias.Add(gdb);
            ge.HoraInicio = "15:00";
            ge.HoraFin = "18:00";
            gf.LstDias.Add(gdc);
            gf.LstDias.Add(gde);
            gf.HoraInicio = "13:00";
            gf.HoraFin = "20:00";
            gg.LstDias.Add(gda);
            gg.LstDias.Add(gdc);
            gg.LstDias.Add(gde);
            gg.HoraInicio = "10:00";
            gg.HoraFin = "22:00";
            gh.LstDias.Add(gdc);
            gh.LstDias.Add(gde);
            gh.HoraInicio = "13:00";
            gh.HoraFin = "20:00";
            gi.LstDias.Add(gda);
            gi.LstDias.Add(gdb);
            gi.HoraInicio = "13:00";
            gi.HoraFin = "20:00";
            gj.LstDias.Add(gda);
            gj.LstDias.Add(gdb);
            gj.LstDias.Add(gde);
            gj.HoraInicio = "13:00";
            gj.HoraFin = "20:00";
            gk.LstDias.Add(gda);
            gk.LstDias.Add(gde);
            gk.HoraInicio = "13:00";
            gk.HoraFin = "20:00";
            gl.LstDias.Add(gda);
            gl.LstDias.Add(gde);
            gl.HoraInicio = "13:00";
            gl.HoraFin = "20:00";
            gm.LstDias.Add(gdb);
            gm.LstDias.Add(gdd);
            gm.LstDias.Add(gde);
            gm.HoraInicio = "13:00";
            gm.HoraFin = "20:00";

            #endregion

            #region ingreso Funcionarios
            Funcionario fua = new Funcionario(sa, "12843332", "Geronimo Paredes", "geronimo@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1970, 12, 1), true);
            Funcionario fub = new Funcionario(sa, "22843332", "Anibal Gimenez", "Anibal@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1975, 12, 1), true);
            Funcionario fuc = new Funcionario(sa, "32843332", "Alberto Beltran", "Alberto@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1978, 12, 1), true);
            Funcionario fud = new Funcionario(sa, "42843332", "Guillermo Huerta", "Guillermo@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1980, 12, 1), true);
            Funcionario fue = new Funcionario(sa, "52843332", "Esteban Martinez", "Esteban@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1982, 12, 1), true);
            Funcionario fuf = new Funcionario(sc, "62843332", "Marta Sanchez", "Marta@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1985, 12, 1), true);
            Funcionario fug = new Funcionario(sc, "72843332", "Veronica Castro", "Veronica@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1988, 12, 1), false);
            Funcionario fuh = new Funcionario(sa, "82843332", "Lucia Perdomo", "Lucia@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1950, 12, 1), true);
            Funcionario fui = new Funcionario(sb, "92843332", "Miguel Angel Gonzalez", "Miguel@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1970, 12, 1), true);
            Funcionario fuj = new Funcionario(sc, "11843332", "Jose Torreon", "Jose@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1990, 12, 1), true);
            Funcionario fuk = new Funcionario(sb, "13843332", "Camila De La Rosa", "Camila@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1992, 12, 1), true);
            Funcionario ful = new Funcionario(sb, "12843332", "Patrica Marquez", "Patrica@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1939, 12, 1), true);
            Funcionario fum = new Funcionario(sc, "14843332", "Lilian Rossi", "Lilian@institutobritanico.com", "claveGeronimo", "3242342", "Riverense 1232", "42342323", new DateTime(1962, 12, 1), false);
            fua.TipoFuncionario = FuncionarioTipo.Profesor;
            fuc.TipoFuncionario = FuncionarioTipo.Profesor;
            fuf.TipoFuncionario = FuncionarioTipo.Profesor;
            fue.TipoFuncionario = FuncionarioTipo.Profesor;
            fuj.TipoFuncionario = FuncionarioTipo.Profesor;
            fuk.TipoFuncionario = FuncionarioTipo.Profesor;
            lstFuncionarios.Add(fua);
            lstFuncionarios.Add(fub);
            lstFuncionarios.Add(fuc);
            lstFuncionarios.Add(fud);
            lstFuncionarios.Add(fue);
            lstFuncionarios.Add(fuf);
            lstFuncionarios.Add(fug);
            lstFuncionarios.Add(fuh);
            lstFuncionarios.Add(fui);
            lstFuncionarios.Add(fuj);
            lstFuncionarios.Add(fuk);
            lstFuncionarios.Add(ful);
            lstFuncionarios.Add(fum);
            #endregion

            #region ingreso estudiantes
            Estudiantes.Add(new Estudiante() { CI = "10671312", Nombre = "Prudencio Hernandez" });
            Estudiantes.Add(new Estudiante() { CI = "11147443", Nombre = "Julio Pardo" });
            Estudiantes.Add(new Estudiante() { CI = "11432894", Nombre = "Gualberto Paez" });
            Estudiantes.Add(new Estudiante() { CI = "11522081", Nombre = "Juan Franco" });
            Estudiantes.Add(new Estudiante() { CI = "11751375", Nombre = "Julio Anadon" });
            Estudiantes.Add(new Estudiante() { CI = "11867459", Nombre = "daniel muñoz" });
            Estudiantes.Add(new Estudiante() { CI = "11899848", Nombre = "Nidia Correa" });
            Estudiantes.Add(new Estudiante() { CI = "11997290", Nombre = "Batriz Casal" });
            Estudiantes.Add(new Estudiante() { CI = "12030968", Nombre = "Silvia Aufman" });
            Estudiantes.Add(new Estudiante() { CI = "12092287", Nombre = "Federico Villaronga" });
            Estudiantes.Add(new Estudiante() { CI = "12563373", Nombre = "Javier Lema" });
            Estudiantes.Add(new Estudiante() { CI = "13109623", Nombre = "Javier Ruiz" });
            Estudiantes.Add(new Estudiante() { CI = "13382968", Nombre = "Alberto Beiro" });
            Estudiantes.Add(new Estudiante() { CI = "13432551", Nombre = "Rafael Barret" });
            Estudiantes.Add(new Estudiante() { CI = "13434634", Nombre = "Silvio Fernandez" });
            Estudiantes.Add(new Estudiante() { CI = "13491931", Nombre = "Horacio Castro" });
            Estudiantes.Add(new Estudiante() { CI = "13512795", Nombre = "Turi Rios" });
            Estudiantes.Add(new Estudiante() { CI = "13546778", Nombre = "Angel Villafan" });
            Estudiantes.Add(new Estudiante() { CI = "13554121", Nombre = "Juan Pedro Flores" });
            Estudiantes.Add(new Estudiante() { CI = "13591949", Nombre = "Enrique Fleitas" });
            Estudiantes.Add(new Estudiante() { CI = "13994416", Nombre = "Hector Silveira" });
            Estudiantes.Add(new Estudiante() { CI = "14018900", Nombre = "Carmelo Umpierrez" });
            Estudiantes.Add(new Estudiante() { CI = "14148688", Nombre = "José Camacho" });
            Estudiantes.Add(new Estudiante() { CI = "14367628", Nombre = "Fernando Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "14449597", Nombre = "Hebert Viojo" });
            Estudiantes.Add(new Estudiante() { CI = "14607347", Nombre = "Raul De María" });
            Estudiantes.Add(new Estudiante() { CI = "14817106", Nombre = "Miriam Alonso" });
            Estudiantes.Add(new Estudiante() { CI = "14850928", Nombre = "Sergio De Furia" });
            Estudiantes.Add(new Estudiante() { CI = "14951526", Nombre = "Vicente Ubbriaco" });
            Estudiantes.Add(new Estudiante() { CI = "15030278", Nombre = "Marcelo Fernandez" });
            Estudiantes.Add(new Estudiante() { CI = "15126986", Nombre = "Pedro Ferrer" });
            Estudiantes.Add(new Estudiante() { CI = "15141437", Nombre = "Carlos Diaz" });
            Estudiantes.Add(new Estudiante() { CI = "15237612", Nombre = "Ruben Olivera" });
            Estudiantes.Add(new Estudiante() { CI = "15288445", Nombre = "Walter Perez" });
            Estudiantes.Add(new Estudiante() { CI = "15561823", Nombre = "Yenny Bell" });
            Estudiantes.Add(new Estudiante() { CI = "15670915", Nombre = "Ruben Schiavo" });
            Estudiantes.Add(new Estudiante() { CI = "15760607", Nombre = "Sergio Romero" });
            Estudiantes.Add(new Estudiante() { CI = "15821322", Nombre = "Luis Ferrer" });
            Estudiantes.Add(new Estudiante() { CI = "15885837", Nombre = "Yoel Baruch" });
            Estudiantes.Add(new Estudiante() { CI = "15950595", Nombre = "Beatriz Agarrayua" });
            Estudiantes.Add(new Estudiante() { CI = "15954927", Nombre = "Ana Maria Cabrera" });
            Estudiantes.Add(new Estudiante() { CI = "16463751", Nombre = "Andres Romero" });
            Estudiantes.Add(new Estudiante() { CI = "16724840", Nombre = "Washington Peña" });
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
            Estudiantes.Add(new Estudiante() { CI = "34302303", Nombre = "Marcos Fernandez" });
            Estudiantes.Add(new Estudiante() { CI = "34303357", Nombre = "Gabriel Vazquez" });
            Estudiantes.Add(new Estudiante() { CI = "34347123", Nombre = "Jilmar Lafón" });
            Estudiantes.Add(new Estudiante() { CI = "34397980", Nombre = "Adriana Pereyra" });
            Estudiantes.Add(new Estudiante() { CI = "34417596", Nombre = "Rodrigo Cotelo" });
            Estudiantes.Add(new Estudiante() { CI = "34498061", Nombre = "Hugo Zapatta" });
            Estudiantes.Add(new Estudiante() { CI = "34500359", Nombre = "Pablo Valdez" });
            Estudiantes.Add(new Estudiante() { CI = "34659910", Nombre = "Gonzalo Almiron" });
            Estudiantes.Add(new Estudiante() { CI = "34795178", Nombre = "Edgardo Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "34823331", Nombre = "Federico Sanchez" });
            Estudiantes.Add(new Estudiante() { CI = "35165996", Nombre = "Nicolas Sosa" });
            Estudiantes.Add(new Estudiante() { CI = "35268291", Nombre = "Fernando Molina" });
            Estudiantes.Add(new Estudiante() { CI = "35725532", Nombre = "Esteban Carballo" });
            Estudiantes.Add(new Estudiante() { CI = "35806899", Nombre = "Jesús Gonzalo Nuñez" });
            Estudiantes.Add(new Estudiante() { CI = "35832911", Nombre = "Manuel Vazquez" });
            Estudiantes.Add(new Estudiante() { CI = "35841954", Nombre = "Gaston Cane" });
            Estudiantes.Add(new Estudiante() { CI = "35881962", Nombre = "Manuel Gomez" });
            Estudiantes.Add(new Estudiante() { CI = "36131469", Nombre = "Fabian Pastorelli" });
            Estudiantes.Add(new Estudiante() { CI = "36171574", Nombre = "Javier Valiente" });
            Estudiantes.Add(new Estudiante() { CI = "36462634", Nombre = "Osmar Fernandez" });
            Estudiantes.Add(new Estudiante() { CI = "36479801", Nombre = "Lujan Tejeira" });
            Estudiantes.Add(new Estudiante() { CI = "36579546", Nombre = "Thevenet, German" });
            Estudiantes.Add(new Estudiante() { CI = "36849509", Nombre = "Alfredo Artus" });
            Estudiantes.Add(new Estudiante() { CI = "37087768", Nombre = "Luis Fernandez" });
            Estudiantes.Add(new Estudiante() { CI = "37142257", Nombre = "Daniel Folonier" });
            Estudiantes.Add(new Estudiante() { CI = "37180007", Nombre = "German De Leon" });
            Estudiantes.Add(new Estudiante() { CI = "37228633", Nombre = "David Garcia" });
            Estudiantes.Add(new Estudiante() { CI = "37289481", Nombre = "Julio Ribas" });
            Estudiantes.Add(new Estudiante() { CI = "37431513", Nombre = "Fernando Olmedo" });
            Estudiantes.Add(new Estudiante() { CI = "37704722", Nombre = "David Carsin" });
            Estudiantes.Add(new Estudiante() { CI = "37887344", Nombre = "Leandro Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "37983340", Nombre = "Gustavo Ismael Lopez" });
            Estudiantes.Add(new Estudiante() { CI = "38134770", Nombre = "Pedro D`aloia" });
            Estudiantes.Add(new Estudiante() { CI = "38147480", Nombre = "Pablo Bulla" });
            Estudiantes.Add(new Estudiante() { CI = "38159942", Nombre = "Rodrigo Sosa" });
            Estudiantes.Add(new Estudiante() { CI = "38754079", Nombre = "Diego Montado" });
            Estudiantes.Add(new Estudiante() { CI = "38915821", Nombre = "Gabriel D´ Atri" });
            Estudiantes.Add(new Estudiante() { CI = "38927270", Nombre = "Jorger Barattini" });
            Estudiantes.Add(new Estudiante() { CI = "38955077", Nombre = "Victor Graña" });
            Estudiantes.Add(new Estudiante() { CI = "38992055", Nombre = "Federico Garrido" });
            Estudiantes.Add(new Estudiante() { CI = "39241536", Nombre = "Getulio Dias" });
            Estudiantes.Add(new Estudiante() { CI = "39257680", Nombre = "Fernando Alvez" });
            Estudiantes.Add(new Estudiante() { CI = "39280487", Nombre = "Gonzalo Pirez" });
            Estudiantes.Add(new Estudiante() { CI = "39343144", Nombre = "Jorge Roman" });
            Estudiantes.Add(new Estudiante() { CI = "39713375", Nombre = "Santiago Orihuela" });
            Estudiantes.Add(new Estudiante() { CI = "39741398", Nombre = "Alejandro Nuñez" });
            Estudiantes.Add(new Estudiante() { CI = "39781516", Nombre = "Rossana Nuñez" });
            Estudiantes.Add(new Estudiante() { CI = "39881900", Nombre = "Mauricio Rios" });
            Estudiantes.Add(new Estudiante() { CI = "39911553", Nombre = "Eduardo Quintana" });
            Estudiantes.Add(new Estudiante() { CI = "39941370", Nombre = "Christian Benelli" });
            Estudiantes.Add(new Estudiante() { CI = "40023298", Nombre = "Jorge Figueredo" });
            Estudiantes.Add(new Estudiante() { CI = "40024026", Nombre = "Daniel Perez" });
            Estudiantes.Add(new Estudiante() { CI = "40045480", Nombre = "Gabriel Perez" });
            Estudiantes.Add(new Estudiante() { CI = "40125793", Nombre = "Nicolas Pereira" });
            Estudiantes.Add(new Estudiante() { CI = "40131201", Nombre = "Pablo Mouriño" });
            Estudiantes.Add(new Estudiante() { CI = "40204886", Nombre = "Marcelo Acosta" });
            Estudiantes.Add(new Estudiante() { CI = "40256237", Nombre = "Miguel Burgos" });
            Estudiantes.Add(new Estudiante() { CI = "40505513", Nombre = "Nicolas Garcia" });
            Estudiantes.Add(new Estudiante() { CI = "40620862", Nombre = "Daniel Bueno" });
            Estudiantes.Add(new Estudiante() { CI = "40678386", Nombre = "Adrian Bonfrisco" });
            Estudiantes.Add(new Estudiante() { CI = "40700454", Nombre = "Juan Odella" });
            Estudiantes.Add(new Estudiante() { CI = "40762325", Nombre = "Gonzalo Sanchez" });
            Estudiantes.Add(new Estudiante() { CI = "40796665", Nombre = "Pablo Sanchez" });
            Estudiantes.Add(new Estudiante() { CI = "40844880", Nombre = "Eduardo Gonzalez" });
            Estudiantes.Add(new Estudiante() { CI = "40851411", Nombre = "Peter Esquivo" });
            Estudiantes.Add(new Estudiante() { CI = "40949525", Nombre = "Rafael Gutierrez" });
            Estudiantes.Add(new Estudiante() { CI = "41019905", Nombre = "Pablo Guillen" });
            Estudiantes.Add(new Estudiante() { CI = "41128100", Nombre = "Miguel Brune" });
            Estudiantes.Add(new Estudiante() { CI = "41131791", Nombre = "Juan Pablo Longo" });
            Estudiantes.Add(new Estudiante() { CI = "41195121", Nombre = "Sebastian Sacra" });
            Estudiantes.Add(new Estudiante() { CI = "41294599", Nombre = "Martin Miranda" });
            Estudiantes.Add(new Estudiante() { CI = "41416393", Nombre = "Michael Acosta" });
            Estudiantes.Add(new Estudiante() { CI = "41542586", Nombre = "Pablo Ascione" });
            Estudiantes.Add(new Estudiante() { CI = "41624320", Nombre = "Ricardo Ortiz" });
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
            Estudiantes.Add(new Estudiante() { CI = "46102064", Nombre = "Alberto Pagano" });
            Estudiantes.Add(new Estudiante() { CI = "46231293", Nombre = "Bernardo Diaz" });
            Estudiantes.Add(new Estudiante() { CI = "46266565", Nombre = "Alfredo Da Souza" });
            Estudiantes.Add(new Estudiante() { CI = "46305521", Nombre = "Jorge Ferrari" });
            Estudiantes.Add(new Estudiante() { CI = "46307193", Nombre = "Damian Ubriaco" });
            Estudiantes.Add(new Estudiante() { CI = "46308147", Nombre = "Jhon Albarenque" });
            Estudiantes.Add(new Estudiante() { CI = "46438665", Nombre = "Pablo Diaz" });
            Estudiantes.Add(new Estudiante() { CI = "46461694", Nombre = "Sebastian Lerena" });
            Estudiantes.Add(new Estudiante() { CI = "46467610", Nombre = "Michel Reboledo" });
            Estudiantes.Add(new Estudiante() { CI = "46481979", Nombre = "Nahuel Pratto" });
            Estudiantes.Add(new Estudiante() { CI = "46587072", Nombre = "Diego Citera" });
            Estudiantes.Add(new Estudiante() { CI = "46638421", Nombre = "Cesar Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "46680634", Nombre = "Gaston Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "46689630", Nombre = "Sebastian Cruz" });
            Estudiantes.Add(new Estudiante() { CI = "46696540", Nombre = "Fernando Sosa" });
            Estudiantes.Add(new Estudiante() { CI = "46746086", Nombre = "Anahi Viera" });
            Estudiantes.Add(new Estudiante() { CI = "46782430", Nombre = "Martin Barth" });
            Estudiantes.Add(new Estudiante() { CI = "46878176", Nombre = "Walter Olmedo" });
            Estudiantes.Add(new Estudiante() { CI = "46968664", Nombre = "Sergio Da Costa" });
            Estudiantes.Add(new Estudiante() { CI = "46980765", Nombre = "Javier Caceres" });
            Estudiantes.Add(new Estudiante() { CI = "47008926", Nombre = "Diego Jackson" });
            Estudiantes.Add(new Estudiante() { CI = "47097559", Nombre = "Christian Dios" });
            Estudiantes.Add(new Estudiante() { CI = "47177470", Nombre = "Corujo, nicolas" });
            Estudiantes.Add(new Estudiante() { CI = "47229641", Nombre = "Walter Correa" });
            Estudiantes.Add(new Estudiante() { CI = "47260136", Nombre = "Rubens Galarraga" });
            Estudiantes.Add(new Estudiante() { CI = "47265631", Nombre = "Renzo Faggiani" });
            Estudiantes.Add(new Estudiante() { CI = "47303364", Nombre = "Cristian Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "47395165", Nombre = "Nicolas Ortiz" });
            Estudiantes.Add(new Estudiante() { CI = "47408281", Nombre = "Sebastian Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "47563861", Nombre = "Sebastian Cortazzo" });
            Estudiantes.Add(new Estudiante() { CI = "47609944", Nombre = "Gabriel Mendez" });
            Estudiantes.Add(new Estudiante() { CI = "47612983", Nombre = "Vanessa Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "47638961", Nombre = "Juan Santos" });
            Estudiantes.Add(new Estudiante() { CI = "47644106", Nombre = "Ignacio Pirez" });
            Estudiantes.Add(new Estudiante() { CI = "47876113", Nombre = "Maximiliano Ferrari" });
            Estudiantes.Add(new Estudiante() { CI = "48031263", Nombre = "Denisse Suarez" });
            Estudiantes.Add(new Estudiante() { CI = "48040820", Nombre = "Ignacio Fernandez" });
            Estudiantes.Add(new Estudiante() { CI = "48303177", Nombre = "German Foglino" });
            Estudiantes.Add(new Estudiante() { CI = "48364470", Nombre = "Javier Arijon" });
            Estudiantes.Add(new Estudiante() { CI = "48401416", Nombre = "Tatianna Nieves" });
            Estudiantes.Add(new Estudiante() { CI = "48494584", Nombre = "Franco Rodriguez" });
            Estudiantes.Add(new Estudiante() { CI = "48499255", Nombre = "Marcelo Diaz" });
            Estudiantes.Add(new Estudiante() { CI = "48641547", Nombre = "Mathias Alpuy" });
            Estudiantes.Add(new Estudiante() { CI = "48748230", Nombre = "Camila Colomar" });
            Estudiantes.Add(new Estudiante() { CI = "48786513", Nombre = "Augusto Braica" });
            Estudiantes.Add(new Estudiante() { CI = "49658583", Nombre = "Gerardo Arguello" });
            Estudiantes.Add(new Estudiante() { CI = "49968231", Nombre = "Michael Paleo" });
            Estudiantes.Add(new Estudiante() { CI = "50757621", Nombre = "Luis Silva" });
            Estudiantes.Add(new Estudiante() { CI = "50800175", Nombre = "Nicolas Morena" });
            Estudiantes.Add(new Estudiante() { CI = "51045489", Nombre = "Martin Figeras" });
            Estudiantes.Add(new Estudiante() { CI = "51261734", Nombre = "Pablo Keller" });
            Estudiantes.Add(new Estudiante() { CI = "52267886", Nombre = "Carolina Lopez" });
            Estudiantes.Add(new Estudiante() { CI = "53375925", Nombre = "Nahuel Rigoleto" });
            Estudiantes.Add(new Estudiante() { CI = "53599802", Nombre = "Marcelo Suarez" });
            Estudiantes.Add(new Estudiante() { CI = "53974898", Nombre = "Jonathan Tejera" });
            Estudiantes.Add(new Estudiante() { CI = "54511249", Nombre = "Jeronimo Traverso" });
            Estudiantes.Add(new Estudiante() { CI = "55093220", Nombre = "Alejandro Tonelli" });
            Estudiantes.Add(new Estudiante() { CI = "55094371", Nombre = "Marcela Marichal" });
            Estudiantes.Add(new Estudiante() { CI = "7691549", Nombre = "Ruben Alvarez" });
            Estudiantes.Add(new Estudiante() { CI = "7896270", Nombre = "Horacio Villar" });

            int i = 0;
            int ii = 0;
            foreach (Estudiante es in Estudiantes)
            {
                es.Email = es.Nombre.Trim() + "@gmail.com";
                es.ID = i;
                i++;
                if (ii == 11) ii = 0;
                if (ii == 0)
                {
                    es.Grupo = ga;
                    ga.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = sa, Matricula = mata, Descuento = 0, FechaHora = new DateTime(2019, 02, 20), Grupo = ga, ID = i, Precio = mata.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 1)
                {
                    es.Grupo = gb;
                    gb.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = matb.Sucursal, Matricula = mata, Descuento = 0, FechaHora = new DateTime(2019, 02, 21), Grupo = gb, ID = i, Precio = matb.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 2)
                {
                    es.Grupo = gc;
                    gc.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = matc.Sucursal, Matricula = matc, Descuento = 0, FechaHora = new DateTime(2019, 02, 22), Grupo = gc, ID = i, Precio = matc.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 3)
                {
                    es.Grupo = gd;
                    gd.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = matd.Sucursal, Matricula = matd, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gc, ID = i, Precio = matd.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 4)
                {
                    es.Grupo = ge;
                    ge.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = mate.Sucursal, Matricula = mate, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gc, ID = i, Precio = mate.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 5)
                {
                    es.Grupo = gf;
                    gf.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fua, Sucursal = mate.Sucursal, Matricula = mate, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gc, ID = i, Precio = mate.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 6)
                {
                    es.Grupo = gg;
                    gg.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fub, Sucursal = matf.Sucursal, Matricula = matf, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gc, ID = i, Precio = matf.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 7)
                {
                    es.Grupo = gh;
                    gh.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fub, Sucursal = mata.Sucursal, Matricula = mata, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gd, ID = i, Precio = mata.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 8)
                {
                    es.Grupo = gi;
                    gi.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fub, Sucursal = mata.Sucursal, Matricula = mata, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = ge, ID = i, Precio = mata.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 9)
                {
                    es.Grupo = gj;
                    gj.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fub, Sucursal = mata.Sucursal, Matricula = mata, Descuento = 0, FechaHora = new DateTime(2019, 02, 23), Grupo = gf, ID = i, Precio = mata.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 10)
                {
                    es.Grupo = gk;
                    gk.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fub, Sucursal = matc.Sucursal, Matricula = matc, Descuento = 0, FechaHora = new DateTime(2018, 02, 23), Grupo = gg, ID = i, Precio = matc.Precio };
                    MatriculasEstudiante.Add(m);
                }
                if (ii == 11)
                {
                    es.Grupo = gl;
                    gl.LstEstudiantes.Add(es);
                    MatriculaEstudiante m = new MatriculaEstudiante() { Estudiante = es, Funcionario = fuc, Sucursal = matd.Sucursal, Matricula = matd, Descuento = 0, FechaHora = new DateTime(2018, 03, 10), Grupo = gh, ID = i, Precio = matd.Precio };
                    MatriculasEstudiante.Add(m);
                }

                ii++;
            }
            #endregion

            #region ingreso libros

            Libro la = new Libro() { ID = 25, Materia = ma, Nombre = "Aprender ingles 101", Precio = 500 };
            Libro lb = new Libro() { ID = 26, Materia = mb, Nombre = "English For Dummies", Precio = 1500 };
            Libro lc = new Libro() { ID = 27, Materia = mc, Nombre = "Educando imberbes", Precio = 500 };
            Libro ld = new Libro() { ID = 28, Materia = md, Nombre = "Sepa la diferencia entre your y your'e", Precio = 500 };
            Libro le = new Libro() { ID = 29, Materia = me, Nombre = "Throwing horse shit for fun", Precio = 500 };
            Libro lf = new Libro() { ID = 30, Materia = mf, Nombre = "Nunca voy a aprender", Precio = 500 };
            Libro lg = new Libro() { ID = 31, Materia = ma, Nombre = "Pa que quiero ingles", Precio = 500 };
            Libro lh = new Libro() { ID = 32, Materia = ma, Nombre = "Frances en 4 simples pasos", Precio = 500 };

            Libros.Add(la);
            Libros.Add(lb);
            Libros.Add(lc);
            Libros.Add(ld);
            Libros.Add(le);
            Libros.Add(lf);
            Libros.Add(lg);
            Libros.Add(lh);
            #endregion

            #region ingreso examenes
            Examen exa = new Examen() { AnioAsociado = 2019, Grupo = ga, ID = 1, NotaMinima = 80, Precio = 5500, FechaHora = new DateTime(2019, 12, 24) };
            Examen exb = new Examen() { AnioAsociado = 2019, Grupo = gb, ID = 2, NotaMinima = 60, Precio = 6500, FechaHora = new DateTime(2019, 11, 12) };
            Examen exc = new Examen() { AnioAsociado = 2019, Grupo = gc, ID = 3, NotaMinima = 60, Precio = 3500, FechaHora = new DateTime(2019, 12, 28) };
            Examen exd = new Examen() { AnioAsociado = 2019, Grupo = gd, ID = 4, NotaMinima = 70, Precio = 2500, FechaHora = new DateTime(2019, 12, 25) };
            Examen exe = new Examen() { AnioAsociado = 2019, Grupo = ge, ID = 5, NotaMinima = 80, Precio = 5800, FechaHora = new DateTime(2019, 10, 2) };
            Examen exf = new Examen() { AnioAsociado = 2019, Grupo = gf, ID = 6, NotaMinima = 70, Precio = 9500, FechaHora = new DateTime(2019, 12, 31) };
            Examen exg = new Examen() { AnioAsociado = 2018, Grupo = ga, ID = 7, NotaMinima = 76, Precio = 7500, FechaHora = new DateTime(2018, 12, 24) };
            Examen exh = new Examen() { AnioAsociado = 2018, Grupo = gb, ID = 8, NotaMinima = 65, Precio = 8500, FechaHora = new DateTime(2018, 10, 2) };
            Examen exi = new Examen() { AnioAsociado = 2018, Grupo = gc, ID = 9, NotaMinima = 70, Precio = 4200, FechaHora = new DateTime(2018, 12, 25) };
            Examen exj = new Examen() { AnioAsociado = 2018, Grupo = gd, ID = 10, NotaMinima = 70, Precio = 15000, FechaHora = new DateTime(2018, 1, 20) };
            Examen exk = new Examen() { AnioAsociado = 2018, Grupo = ge, ID = 11, NotaMinima = 80, Precio = 2500, FechaHora = new DateTime(2018, 11, 7) };
            Examenes.Add(exa);
            Examenes.Add(exb);
            Examenes.Add(exc);
            Examenes.Add(exd);
            Examenes.Add(exe);
            Examenes.Add(exf);
            Examenes.Add(exg);
            Examenes.Add(exh);
            Examenes.Add(exj);
            Examenes.Add(exk);
            #endregion


            #region ingreso de pagos

            Pago pa = new Pago() { Concepto = "UTE", FechaHora = new DateTime(2019, 02, 24), Funcionario = fua, ID = 1, Monto = 3000, Sucursal = sa };
            Pago pb = new Pago() { Concepto = "OSE", FechaHora = new DateTime(2019, 02, 25), Funcionario = fua, ID = 2, Monto = 4000, Sucursal = sa };
            Pago pc = new Pago() { Concepto = "Antel", FechaHora = new DateTime(2019, 02, 20), Funcionario = fub, ID = 3, Monto = 2000, Sucursal = sa };
            Pago pd = new Pago() { Concepto = "Papel Higienico", FechaHora = new DateTime(2019, 01, 24), Funcionario = fub, ID = 4, Monto = 83000, Sucursal = sa };
            Pago pe = new Pago() { Concepto = "Sueldos", FechaHora = new DateTime(2019, 02, 10), Funcionario = fub, ID = 5, Monto = 1000, Sucursal = sa };
            Pago pf = new Pago() { Concepto = "Hojas A4", FechaHora = new DateTime(2019, 01, 15), Funcionario = fub, ID = 6, Monto = 4500, Sucursal = sc };
            Pago pg = new Pago() { Concepto = "Cafe", FechaHora = new DateTime(2019, 03, 24), Funcionario = fua, ID = 7, Monto = 30000, Sucursal = sc };
            Pago ph = new Pago() { Concepto = "UTE", FechaHora = new DateTime(2019, 03, 24), Funcionario = fua, ID = 8, Monto = 2000, Sucursal = sc };
            Pago pi = new Pago() { Concepto = "OSE", FechaHora = new DateTime(2019, 03, 24), Funcionario = fub, ID = 9, Monto = 2100, Sucursal = sc };
            Pago pj = new Pago() { Concepto = "Alquiler", FechaHora = new DateTime(2019, 04, 2), Funcionario = fub, ID = 10, Monto = 23000, Sucursal = sa };
            Pago pk = new Pago() { Concepto = "Lapiceras", FechaHora = new DateTime(2019, 04, 24), Funcionario = fuc, ID = 11, Monto = 6000, Sucursal = sb };
            Pago pl = new Pago() { Concepto = "Mesas", FechaHora = new DateTime(2019, 05, 24), Funcionario = fuc, ID = 12, Monto = 500, Sucursal = sb };
            Pago pm = new Pago() { Concepto = "Azucar", FechaHora = new DateTime(2019, 05, 24), Funcionario = fud, ID = 13, Monto = 800, Sucursal = sb };
            Pago pn = new Pago() { Concepto = "Jabon", FechaHora = new DateTime(2019, 05, 24), Funcionario = fud, ID = 14, Monto = 1000, Sucursal = sb };
            Pago po = new Pago() { Concepto = "Sueldos", FechaHora = new DateTime(2019, 03, 24), Funcionario = fub, ID = 15, Monto = 700, Sucursal = sb };
            Pago pp = new Pago() { Concepto = "Antel", FechaHora = new DateTime(2019, 01, 24), Funcionario = fub, ID = 16, Monto = 1200, Sucursal = sa };
            Pago pq = new Pago() { Concepto = "UTE", FechaHora = new DateTime(2018, 01, 24), Funcionario = fub, ID = 17, Monto = 4500, Sucursal = sa };
            Pago pr = new Pago() { Concepto = "UTE", FechaHora = new DateTime(2018, 04, 24), Funcionario = fub, ID = 18, Monto = 4600, Sucursal = sa };

            Pagos.Add(pa);
            Pagos.Add(pb);
            Pagos.Add(pc);
            Pagos.Add(pd);
            Pagos.Add(pe);
            Pagos.Add(pf);
            Pagos.Add(pg);
            Pagos.Add(ph);
            Pagos.Add(pi);
            Pagos.Add(pj);
            Pagos.Add(pk);
            Pagos.Add(pl);
            Pagos.Add(pm);
            Pagos.Add(pn);
            Pagos.Add(po);
            Pagos.Add(pp);
            Pagos.Add(pq);
            Pagos.Add(pr);

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


