using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Cast.Data
{
    public class US_State
    {
        public string Name { get; set; }
        public string Abbreviations { get; set; }
        private List<US_State> US_States { get; set; }
        public US_State()
        {
            US_States = new List<US_State>();
        }
        private US_State(string name, string abbr)
        {
            this.Name = name;
            this.Abbreviations = abbr;
        }
        public List<US_State> GetStates()
        {
    
            US_States.Add(new US_State("AL", "Alabama"));
            US_States.Add(new US_State("AK", "Alaska"));
            US_States.Add(new US_State("AZ", "Arizona"));
            US_States.Add(new US_State("AR", "Arkansas"));
            US_States.Add(new US_State("CA", "California"));
            US_States.Add(new US_State("CO", "Colorado"));
            US_States.Add(new US_State("CT", "Connecticut"));
            US_States.Add(new US_State("DE", "Delaware"));
            US_States.Add(new US_State("DC", "District Of Columbia"));
            US_States.Add(new US_State("FL", "Florida"));
            US_States.Add(new US_State("GA", "Georgia"));
            US_States.Add(new US_State("HI", "Hawaii"));
            US_States.Add(new US_State("ID", "Idaho"));
            US_States.Add(new US_State("IL", "Illinois"));
            US_States.Add(new US_State("IN", "Indiana"));
            US_States.Add(new US_State("IA", "Iowa"));
            US_States.Add(new US_State("KS", "Kansas"));
            US_States.Add(new US_State("KY", "Kentucky"));
            US_States.Add(new US_State("LA", "Louisiana"));
            US_States.Add(new US_State("ME", "Maine"));
            US_States.Add(new US_State("MD", "Maryland"));
            US_States.Add(new US_State("MA", "Massachusetts"));
            US_States.Add(new US_State("MI", "Michigan"));
            US_States.Add(new US_State("MN", "Minnesota"));
            US_States.Add(new US_State("MS", "Mississippi"));
            US_States.Add(new US_State("MO", "Missouri"));
            US_States.Add(new US_State("MT", "Montana"));
            US_States.Add(new US_State("NE", "Nebraska"));
            US_States.Add(new US_State("NV", "Nevada"));
            US_States.Add(new US_State("NH", "New Hampshire"));
            US_States.Add(new US_State("NJ", "New Jersey"));
            US_States.Add(new US_State("NM", "New Mexico"));
            US_States.Add(new US_State("NY", "New York"));
            US_States.Add(new US_State("NC", "North Carolina"));
            US_States.Add(new US_State("ND", "North Dakota"));
            US_States.Add(new US_State("OH", "Ohio"));
            US_States.Add(new US_State("OK", "Oklahoma"));
            US_States.Add(new US_State("OR", "Oregon"));
            US_States.Add(new US_State("PA", "Pennsylvania"));
            US_States.Add(new US_State("RI", "Rhode Island"));
            US_States.Add(new US_State("SC", "South Carolina"));
            US_States.Add(new US_State("SD", "South Dakota"));
            US_States.Add(new US_State("TN", "Tennessee"));
            US_States.Add(new US_State("TX", "Texas"));
            US_States.Add(new US_State("UT", "Utah"));
            US_States.Add(new US_State("VT", "Vermont"));
            US_States.Add(new US_State("VA", "Virginia"));
            US_States.Add(new US_State("WA", "Washington"));
            US_States.Add(new US_State("WV", "West Virginia"));
            US_States.Add(new US_State("WI", "Wisconsin"));
            US_States.Add(new US_State("WY", "Wyoming"));

            return US_States;
        }
    }
}
