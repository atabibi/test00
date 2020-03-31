using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TbPeopleList
{
    public class PersonForExcel
    {
        [Name("ردیف")]
        public int Id { get; set; }

        [Name("نام کامل")]
        public string FullName { get; set; }

        [Name("جنس")]
        public string Gender { get; set; }

        [Name("مبلغ")]
        public decimal Mablagh { get; set; }

        [Name("کد ملی")]
        public string CodeMelli { get; set; }

        [Name("پدر یا مادر")]
        public string Parent { get; set; }

        [Name("جد یا جده")]
        public string Jad { get; set; }

        [Name("شماره حساب")]
        public string ShomareHesab { get; set; }

        [Name("شماره کارت")]
        public string ShomareCard { get; set; }

        [Name("توضیحات")]
        public string Desc { get; set; }
    }
}
