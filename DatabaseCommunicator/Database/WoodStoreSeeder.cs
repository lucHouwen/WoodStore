using DatabaseCommunicator.Classes;
using System.Collections.Generic;
using System.Data.Entity;

namespace DatabaseCommunicator
{
   public class WoodStoreSeeder :
    //DropCreateDatabaseAlways<WoodStoreDbContext>
    DropCreateDatabaseIfModelChanges<WoodStoreDbContext>
    {
        protected override void Seed(WoodStoreDbContext ctx)
        {
            ctx.Accounts.Add(new Account("b", "b", false)); // customer account
            ctx.Accounts.Add(new Account("a", "a", true));  // Admin account

            Color color = new Color("mycustomcolor");
            ctx.Colors.Add(color);

            Plinth plinth = new Plinth("ParketPlint",Unit.Piece,4,"plinthPic", "ref321321231", "Woodstore plint",2400,14,60,color,false);
            Plinth standaardPlinth = new Plinth("StandaardPlint", Unit.Piece, 4, "plinthPic", "ref1231", "Woodstore plint", 2400, 14, 60, color,true);

            ctx.Products.Add(plinth);
            ctx.Products.Add(standaardPlinth);

            Profile prof = new Profile("profiel", Unit.Piece, 5, "profielPic", "refaaaaaaa", "WoodstoreProfiel", 2000, 44, 12.3, color, false);
            Profile Standaardprof = new Profile("profiel", Unit.Piece, 5, "profielPic", "refbbbbbbbb", "WoodstoreProfiel", 2000, 44, 12.3, color, true);

            ctx.Products.Add(prof);
            ctx.Products.Add(Standaardprof);

            List<FloorCovering> fc = new List<FloorCovering>();
            fc.Add(plinth);

            ctx.Products.Add(new Parquet("LuxeParket",Unit.Box,12,"mypicturepath", "refparquet321", color,"superkliksysteem",
                             1100,111,20,8,50,12,fc));

            ctx.Countries.Add(new Country("Afghanistan"));
            //ctx.Countries.Add(new Country("Albania"));
            //ctx.Countries.Add(new Country("Algeria"));
            //ctx.Countries.Add(new Country("Andorra"));
            //ctx.Countries.Add(new Country("Angola"));
            //ctx.Countries.Add(new Country("Argentina"));
            //ctx.Countries.Add(new Country("Armenia"));
            //ctx.Countries.Add(new Country("Australia"));
            //ctx.Countries.Add(new Country("Austria"));
            //ctx.Countries.Add(new Country("Azerbaijan"));

            //ctx.Countries.Add(new Country("Bahamas"));
            //ctx.Countries.Add(new Country("Bahrain"));
            //ctx.Countries.Add(new Country("Bangladesh"));
            //ctx.Countries.Add(new Country("Barbados"));
            //ctx.Countries.Add(new Country("Belarus"));
            //ctx.Countries.Add(new Country("Belgium"));
            //ctx.Countries.Add(new Country("Belize"));
            //ctx.Countries.Add(new Country("Benin"));
            //ctx.Countries.Add(new Country("Bhutan"));
            //ctx.Countries.Add(new Country("Bolivia"));
            //ctx.Countries.Add(new Country("Bosnia and Herzegovina "));
            //ctx.Countries.Add(new Country("Botswana"));
            //ctx.Countries.Add(new Country("Brazil"));
            //ctx.Countries.Add(new Country("Brunei"));
            //ctx.Countries.Add(new Country("Bulgaria"));
            //ctx.Countries.Add(new Country("Burkina Faso"));
            //ctx.Countries.Add(new Country("Burundi"));

            //ctx.Countries.Add(new Country("Cabo Verde "));
            //ctx.Countries.Add(new Country("Cambodia"));
            //ctx.Countries.Add(new Country("Cameroon"));
            //ctx.Countries.Add(new Country("Canada"));
            //ctx.Countries.Add(new Country("Central African Republic (CAR)"));
            //ctx.Countries.Add(new Country("Chad"));
            //ctx.Countries.Add(new Country("Chile"));
            //ctx.Countries.Add(new Country("China"));
            //ctx.Countries.Add(new Country("Colombia"));
            //ctx.Countries.Add(new Country("Comoros"));
            //ctx.Countries.Add(new Country("Congo"));
            //ctx.Countries.Add(new Country("Costa Rica"));
            //ctx.Countries.Add(new Country("Cote d'Ivoire"));
            //ctx.Countries.Add(new Country("Croatia"));
            //ctx.Countries.Add(new Country("Cuba"));
            //ctx.Countries.Add(new Country("Cyprus"));
            //ctx.Countries.Add(new Country("Czech Republic "));

            //ctx.Countries.Add(new Country("Denmark"));
            //ctx.Countries.Add(new Country("Djibouti"));
            //ctx.Countries.Add(new Country("Dominica"));
            //ctx.Countries.Add(new Country("Dominican Republic"));

            //ctx.Countries.Add(new Country("Ecuador"));
            //ctx.Countries.Add(new Country("Egypt"));
            //ctx.Countries.Add(new Country("El Salvador"));
            //ctx.Countries.Add(new Country("Equatorial Guinea")); 
            //ctx.Countries.Add(new Country("Eritrea"));
            //ctx.Countries.Add(new Country("Estonia"));
            //ctx.Countries.Add(new Country("Ethiopia"));

            //ctx.Countries.Add(new Country("Fiji"));
            //ctx.Countries.Add(new Country("Finland"));
            //ctx.Countries.Add(new Country("France"));

            //ctx.Countries.Add(new Country("Gabon"));
            //ctx.Countries.Add(new Country("Gambia"));
            //ctx.Countries.Add(new Country("Georgia"));
            //ctx.Countries.Add(new Country("Germany"));
            //ctx.Countries.Add(new Country("Ghana"));
            //ctx.Countries.Add(new Country("Greece"));
            //ctx.Countries.Add(new Country("Grenada"));
            //ctx.Countries.Add(new Country("Guatemala"));
            //ctx.Countries.Add(new Country("Guinea"));
            //ctx.Countries.Add(new Country("Guinea-Bissau "));
            //ctx.Countries.Add(new Country("Guyana"));

            //ctx.Countries.Add(new Country("Haiti"));
            //ctx.Countries.Add(new Country("Honduras"));
            //ctx.Countries.Add(new Country("Hungary"));

            //ctx.Countries.Add(new Country("Iceland"));
            //ctx.Countries.Add(new Country("India"));
            //ctx.Countries.Add(new Country("Indonesia"));
            //ctx.Countries.Add(new Country("Iran"));
            //ctx.Countries.Add(new Country("Iraq"));
            //ctx.Countries.Add(new Country("Ireland"));
            //ctx.Countries.Add(new Country("Israel"));
            //ctx.Countries.Add(new Country("Italy"));

            //ctx.Countries.Add(new Country("Jamaica"));
            //ctx.Countries.Add(new Country("Japan"));
            //ctx.Countries.Add(new Country("Jordan"));

            //ctx.Countries.Add(new Country("Kazakhstan"));
            //ctx.Countries.Add(new Country("Kenya"));
            //ctx.Countries.Add(new Country("Kiribati"));
            //ctx.Countries.Add(new Country("Kosovo"));
            //ctx.Countries.Add(new Country("Kuwait"));
            //ctx.Countries.Add(new Country("Kyrgyzstan"));

            //ctx.Countries.Add(new Country("Laos"));
            //ctx.Countries.Add(new Country("Latvia"));
            //ctx.Countries.Add(new Country("Lebanon"));
            //ctx.Countries.Add(new Country("Lesotho"));
            //ctx.Countries.Add(new Country("Lesotho"));
            //ctx.Countries.Add(new Country("Libya"));
            //ctx.Countries.Add(new Country("Liechtenstein"));
            //ctx.Countries.Add(new Country("Lithuania"));
            //ctx.Countries.Add(new Country("Luxembourg"));

            //ctx.Countries.Add(new Country("Macedonia"));
            //ctx.Countries.Add(new Country("Madagascar"));
            //ctx.Countries.Add(new Country("Malawi"));
            //ctx.Countries.Add(new Country("Malaysia"));
            //ctx.Countries.Add(new Country("Maldives"));
            //ctx.Countries.Add(new Country("Mali"));
            //ctx.Countries.Add(new Country("Malta"));
            //ctx.Countries.Add(new Country("Marshall Islands"));
            //ctx.Countries.Add(new Country("Mauritania"));
            //ctx.Countries.Add(new Country("Mauritius"));
            //ctx.Countries.Add(new Country("Mexico"));
            //ctx.Countries.Add(new Country("Micronesia"));
            //ctx.Countries.Add(new Country("Moldova"));
            //ctx.Countries.Add(new Country("Monaco"));
            //ctx.Countries.Add(new Country("Mongolia"));
            //ctx.Countries.Add(new Country("Montenegro"));
            //ctx.Countries.Add(new Country("Morocco"));
            //ctx.Countries.Add(new Country("Mozambique"));
            //ctx.Countries.Add(new Country("Myanmar (Burma)"));

            //ctx.Countries.Add(new Country("Namibia"));
            //ctx.Countries.Add(new Country("Nauru"));
            //ctx.Countries.Add(new Country("Nepal"));
            //ctx.Countries.Add(new Country("Netherlands"));
            //ctx.Countries.Add(new Country("New Zealand "));
            //ctx.Countries.Add(new Country("Nicaragua"));
            //ctx.Countries.Add(new Country("Niger"));
            //ctx.Countries.Add(new Country("Nigeria"));
            //ctx.Countries.Add(new Country("North Korea "));
            //ctx.Countries.Add(new Country("Norway"));

            //ctx.Countries.Add(new Country("Oman"));

            //ctx.Countries.Add(new Country("Pakistan"));
            //ctx.Countries.Add(new Country("Palau"));
            //ctx.Countries.Add(new Country("Palestine"));
            //ctx.Countries.Add(new Country("Panama"));
            //ctx.Countries.Add(new Country("Papua New Guinea"));
            //ctx.Countries.Add(new Country("Paraguay"));
            //ctx.Countries.Add(new Country("Peru"));
            //ctx.Countries.Add(new Country("Philippines"));
            //ctx.Countries.Add(new Country("Poland"));
            //ctx.Countries.Add(new Country("Portugal"));

            //ctx.Countries.Add(new Country("Qatar"));

            //ctx.Countries.Add(new Country("Romania"));
            //ctx.Countries.Add(new Country("Russia"));
            //ctx.Countries.Add(new Country("Rwanda"));

            //ctx.Countries.Add(new Country("Saudi Arabia"));
            //ctx.Countries.Add(new Country("Samoa"));
            //ctx.Countries.Add(new Country("San Marino "));
            //ctx.Countries.Add(new Country("Senegal"));
            //ctx.Countries.Add(new Country("Serbia"));
            //ctx.Countries.Add(new Country("Seychelles"));
            //ctx.Countries.Add(new Country("Sierra Leone "));
            //ctx.Countries.Add(new Country("Singapore"));
            //ctx.Countries.Add(new Country("Slovakia"));
            //ctx.Countries.Add(new Country("Slovenia"));
            //ctx.Countries.Add(new Country("Solomon Islands "));
            //ctx.Countries.Add(new Country("Somalia"));
            //ctx.Countries.Add(new Country("South Africa "));
            //ctx.Countries.Add(new Country("South Korea "));
            //ctx.Countries.Add(new Country("South Sudan "));
            //ctx.Countries.Add(new Country("Spain"));
            //ctx.Countries.Add(new Country("Sri Lanka "));
            //ctx.Countries.Add(new Country("Sudan"));
            //ctx.Countries.Add(new Country("Suriname"));
            //ctx.Countries.Add(new Country("Swaziland"));
            //ctx.Countries.Add(new Country("Sweden"));
            //ctx.Countries.Add(new Country("Switzerland"));
            //ctx.Countries.Add(new Country("Syria"));

            //ctx.Countries.Add(new Country("Taiwan"));
            //ctx.Countries.Add(new Country("Tajikistan"));
            //ctx.Countries.Add(new Country("Tanzania"));
            //ctx.Countries.Add(new Country("Thailand"));
            //ctx.Countries.Add(new Country("Timor-Leste "));
            //ctx.Countries.Add(new Country("Togo"));
            //ctx.Countries.Add(new Country("Tonga"));
            //ctx.Countries.Add(new Country("Trinidad and Tobago "));
            //ctx.Countries.Add(new Country("Tunisia"));
            //ctx.Countries.Add(new Country("Turkey"));
            //ctx.Countries.Add(new Country("Turkmenistan"));
            //ctx.Countries.Add(new Country("Tuvalu"));

            //ctx.Countries.Add(new Country("Uganda"));
            //ctx.Countries.Add(new Country("Ukraine"));
            //ctx.Countries.Add(new Country("United Arab Emirates (UAE)"));
            //ctx.Countries.Add(new Country("United Kingdom (UK)"));
            //ctx.Countries.Add(new Country("United States of America (USA)"));
            //ctx.Countries.Add(new Country("Uruguay"));
            //ctx.Countries.Add(new Country("Uzbekistan"));

            //ctx.Countries.Add(new Country("Vanuatu"));
            //ctx.Countries.Add(new Country("Vatican City"));
            //ctx.Countries.Add(new Country("Venezuela"));
            //ctx.Countries.Add(new Country("Vietnam"));

            //ctx.Countries.Add(new Country("Yemen"));

            //ctx.Countries.Add(new Country("Zambia"));
            //ctx.Countries.Add(new Country("Zimbabwe"));
            
            base.Seed(ctx);
        }
    }
}
