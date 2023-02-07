namespace ProjetoTimesheet.Models
{
    public class NovoProjeto
    {
            public string project_name { get; set; }
            public int project_nr { get; set; }
            public string project_status { get; set; }
            public int company_name { get; set; }
            public DateTime end_date_formatted { get; set; }
            public DateTime start_date_formatted { get; set; }
            public string project_type { get; set; }

        
    }
}
