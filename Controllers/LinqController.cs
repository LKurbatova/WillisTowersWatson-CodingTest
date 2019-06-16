using CodingTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CodingTest.Controllers
{
    public class LinqController : Controller
    {
        public IActionResult Index()
        {
            var averageGrade = Math.Round(GradeList.Select(sg => sg.NumberGrade).Average());
            var studentsCountByLetterGrade = from sg in GradeList
                                             group sg by sg.LetterGrade into g orderby g.Key
                                             select new { LetterGrade = g.Key, SudentsCount = g.ToList().Count }.ToExpando();
            var sortedStudents = GradeList.OrderByDescending(sg => sg.NumberGrade).Select(sg => new
            {
                sg.NumberGrade,
                sg.FirstName,
                sg.LastName
            }.ToExpando());

            dynamic model = new ExpandoObject();
            model.AverageGrade = averageGrade;
            model.StudentsCountByLetterGrade = studentsCountByLetterGrade;
            model.SortedStudents = sortedStudents;
            return View(model);
        }

        public static List<StudentGrade> GradeList = new List<StudentGrade>
        {
            new StudentGrade { FirstName="Rosina", LastName="Pickel", NumberGrade=92, LetterGrade="A" },
            new StudentGrade { FirstName="Valene", LastName="Belvin", NumberGrade=75, LetterGrade="C" },
            new StudentGrade { FirstName="Floria", LastName="Dambrosia", NumberGrade=86, LetterGrade="B" },
            new StudentGrade { FirstName="Lindsay", LastName="Slade", NumberGrade=95, LetterGrade="A" },
            new StudentGrade { FirstName="Tia", LastName="Sabat", NumberGrade=86, LetterGrade="B" },
            new StudentGrade { FirstName="Shaunta", LastName="Milani", NumberGrade=88, LetterGrade="B" },
            new StudentGrade { FirstName="Billye", LastName="Bose", NumberGrade=82, LetterGrade="B" },
            new StudentGrade { FirstName="Elvera", LastName="Ayres", NumberGrade=81, LetterGrade="B" },
            new StudentGrade { FirstName="Migdalia", LastName="Rouse", NumberGrade=76, LetterGrade="C" },
            new StudentGrade { FirstName="Kelsie", LastName="Mccord", NumberGrade=83, LetterGrade="B" },
            new StudentGrade { FirstName="Shaquita", LastName="Blackledge", NumberGrade=83, LetterGrade="B" },
            new StudentGrade { FirstName="Kaitlin", LastName="Wurst", NumberGrade=96, LetterGrade="A" },
            new StudentGrade { FirstName="Lacy", LastName="Minear", NumberGrade=76, LetterGrade="C" },
            new StudentGrade { FirstName="Lashaunda", LastName="Raskin", NumberGrade=90, LetterGrade="A" },
            new StudentGrade { FirstName="Bethanie", LastName="Mastronardi", NumberGrade=96, LetterGrade="A" },
            new StudentGrade { FirstName="Joesph", LastName="Peavy", NumberGrade=81, LetterGrade="B" },
            new StudentGrade { FirstName="Fransisca", LastName="Scherr", NumberGrade=66, LetterGrade="D" },
            new StudentGrade { FirstName="Yer", LastName="Schoonover", NumberGrade=90, LetterGrade="A" },
            new StudentGrade { FirstName="Jean", LastName="Monzon", NumberGrade=95, LetterGrade="A" },
            new StudentGrade { FirstName="Elena", LastName="Fickel", NumberGrade=85, LetterGrade="B" },
            new StudentGrade { FirstName="Lynell", LastName="Mcnally", NumberGrade=65, LetterGrade="D" },
            new StudentGrade { FirstName="Leslee", LastName="Babin", NumberGrade=79, LetterGrade="C" },
            new StudentGrade { FirstName="Layne", LastName="Cobler", NumberGrade=79, LetterGrade="C" },
            new StudentGrade { FirstName="Zada", LastName="Dingee", NumberGrade=93, LetterGrade="A" },
            new StudentGrade { FirstName="Ricky", LastName="Vaughan", NumberGrade=79, LetterGrade="C" },
            new StudentGrade { FirstName="Ardella", LastName="Bellah", NumberGrade=75, LetterGrade="C" },
            new StudentGrade { FirstName="Rozella", LastName="Netherland", NumberGrade=68, LetterGrade="D" },
            new StudentGrade { FirstName="Shandra", LastName="Ridley", NumberGrade=79, LetterGrade="C" },
            new StudentGrade { FirstName="Franklyn", LastName="Hoback", NumberGrade=73, LetterGrade="C" },
            new StudentGrade { FirstName="Rufus", LastName="Coblentz", NumberGrade=82, LetterGrade="B"}
        };
    }
}

public static class Extensions
{
    public static ExpandoObject ToExpando(this object anonymousObject)
    {
        IDictionary<string, object> anonymousDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousObject);
        IDictionary<string, object> expando = new ExpandoObject();
        foreach (var item in anonymousDictionary)
            expando.Add(item);
        return (ExpandoObject)expando;
    }
}