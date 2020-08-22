using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using SSIS_BOOT.Common;
using SSIS_BOOT.Models;

namespace SSIS_BOOT.DB
{
    public class SSISSeeder
    {
        public SSISSeeder(SSISContext dbcontext)
        {
            // Seed Permission
            Permission permission1 = new Permission("Employees access Deptemp Controller", "de", "/Deptemp");
            Permission permission2 = new Permission("Department heads access Deptemp Controller", "dh", "/Deptemp");
            Permission permission3 = new Permission("Department heads access Depthead Controller", "dh", "/Depthead");
            Permission permission4 = new Permission("the store clerks access Storeclerk Controller", "sc", "/Storeclerk");
            Permission permission5 = new Permission("the store supervisors access Storeclerk Controller", "ss", "/Storeclerk");
            Permission permission6 = new Permission("the store supervisors access StoresupController", "ss", "/Storesup");
            Permission permission7 = new Permission("the store managers access Storeclerk Controller", "sm", "/Storeclerk");
            Permission permission8 = new Permission("the store managers access Storesup Controller", "sm", "/Storesup");
            Permission permission9 = new Permission("the store managers access Storemgmt Controller", "sm", "/Storemgmt");

            dbcontext.Add(permission1);
            dbcontext.Add(permission2);
            dbcontext.Add(permission3);
            dbcontext.Add(permission4);
            dbcontext.Add(permission5);
            dbcontext.Add(permission6);
            dbcontext.Add(permission7);
            dbcontext.Add(permission8);
            dbcontext.Add(permission9);
            dbcontext.SaveChanges();


            //Seed category
            Category ca1 = new Category("Clip", "C1");
            Category ca2 = new Category("Envelope", "E1");
            Category ca3 = new Category("Eraser", "E2");
            Category ca4 = new Category("Exercises", "E3");
            Category ca5 = new Category("File", "F1");
            Category ca6 = new Category("Pen", "H1");
            Category ca7 = new Category("Puncher", "H2");
            Category ca8 = new Category("Pad", "P1");
            Category ca9 = new Category("Paper", "P2");
            Category ca10 = new Category("Ruler", "R1");
            Category ca11 = new Category("Scissors", "S1");
            Category ca12 = new Category("Tape", "S2");
            Category ca13 = new Category("Sharpener", "S3");
            Category ca14 = new Category("Shorthand", "S4");
            Category ca15 = new Category("Stapler", "S5");
            Category ca16 = new Category("Tacks", "T1");
            Category ca17 = new Category("Tparency", "T2");
            Category ca18 = new Category("Tray", "T3");
            Category ca19 = new Category("Hardware", "D1");

            dbcontext.Add(ca1);
            dbcontext.Add(ca2);
            dbcontext.Add(ca3);
            dbcontext.Add(ca4);
            dbcontext.Add(ca5);
            dbcontext.Add(ca6);
            dbcontext.Add(ca7);
            dbcontext.Add(ca8);
            dbcontext.Add(ca9);
            dbcontext.Add(ca10);
            dbcontext.Add(ca11);
            dbcontext.Add(ca12);
            dbcontext.Add(ca13);
            dbcontext.Add(ca14);
            dbcontext.Add(ca15);
            dbcontext.Add(ca16);
            dbcontext.Add(ca17);
            dbcontext.Add(ca18);
            dbcontext.Add(ca19);
            dbcontext.SaveChanges();


            //seed product
            //public Product(string Id, string Description, int CategoryId, int ReorderLvl, int ReorderQty, string Uom)
            Product p1 = new Product("C001", "Clips Double 1", 1, 15, 15, "Dozen");
            Product p2 = new Product("C002", "Clips Double 2", 1, 30, 50, "Dozen");
            Product p3 = new Product("C003", "Clips Double 3/4", 1, 15, 15, "Dozen");
            Product p4 = new Product("C004", "Clips Paper Large", 1, 15, 15, "Box");
            Product p5 = new Product("E001", "Envelop Brown (3'x6')", 2, 100, 100, "Each");
            Product p6 = new Product("E002", "Envelop Brown (3'x6') w/Window", 2, 100, 100, "Each");
            Product p7 = new Product("E003", "Envelop Brown (6'x7')", 2, 100, 100, "Each");
            Product p8 = new Product("E004", "Envelop Brown (6'x7') w/Window", 2, 100, 100, "Each");
            Product p9 = new Product("E020", "Eraser (hard)", 3, 20, 50, "Each");
            Product p10 = new Product("E021", "Eraser (soft)", 3, 20, 50, "Each");
            Product p11 = new Product("E030", "Exercise Book (100pg)", 4, 100, 100, "Each");
            Product p12 = new Product("E031", "Exercise Book (120pg)", 4, 100, 100, "Each");
            Product p13 = new Product("E032", "Exercise Book A4 Hardcover (100 pg)", 4, 100, 100, "Each");
            Product p14 = new Product("E033", "Exercise Book A5 Hardcover (120 pg)", 4, 100, 100, "Each");
            Product p15 = new Product("F020", "File Separator", 5, 50, 100, "Set");
            Product p16 = new Product("F021", "File-Blue Plain", 5, 50, 100, "Each");
            Product p17 = new Product("F022", "File-Blue with Logo", 5, 100, 200, "Each");
            Product p18 = new Product("F023", "File-Brown w/o Logo", 5, 100, 200, "Each");
            Product p19 = new Product("H011", "Highlighter Blue", 6, 80, 100, "Box");//pen
            Product p20 = new Product("H012", "Highlighter Green", 6, 80, 100, "Box");
            Product p21 = new Product("H013", "Highlighter Pink", 6, 80, 100, "Box");
            Product p22 = new Product("H014", "Highlighter Yellow", 6, 80, 100, "Box");
            Product p23 = new Product("H031", "Hole Puncher 2 holes", 7, 20, 50, "Each");
            Product p24 = new Product("H032", "Hole Puncher 3 holes", 7, 20, 50, "Each");
            Product p25 = new Product("H033", "Hole Puncher Adjustable", 7, 20, 50, "Each");
            Product p26 = new Product("P010", "Pad Postit Memo 1'x2'", 8, 60, 100, "Packet");//8=pad
            Product p27 = new Product("P011", "Pad Postit Memo 1/2'x1'", 8, 60, 100, "Packet");
            Product p28 = new Product("P012", "Pad Postit Memo 1/2'x2'", 8, 60, 100, "Packet");
            Product p29 = new Product("P013", "Pad Postit Memo 2'x3'", 8, 60, 100, "Packet");
            Product p30 = new Product("P043", "Pencil 2b with Eraser End", 6, 100, 500, "Dozen");
            Product p31 = new Product("D001", "Diskettes 3.5 inch (HD)", 19, 20, 30, "Box");
            dbcontext.Add(p1);
            dbcontext.Add(p2);
            dbcontext.Add(p3);
            dbcontext.Add(p4);
            dbcontext.Add(p5);
            dbcontext.Add(p6);
            dbcontext.Add(p7);
            dbcontext.Add(p8);
            dbcontext.Add(p9);
            dbcontext.Add(p10);
            dbcontext.Add(p11);
            dbcontext.Add(p12);
            dbcontext.Add(p13);
            dbcontext.Add(p14);
            dbcontext.Add(p15);
            dbcontext.Add(p16);
            dbcontext.Add(p17);
            dbcontext.Add(p18);
            dbcontext.Add(p19);
            dbcontext.Add(p20);
            dbcontext.Add(p21);
            dbcontext.Add(p22);
            dbcontext.Add(p23);
            dbcontext.Add(p24);
            dbcontext.Add(p25);
            dbcontext.Add(p26);
            dbcontext.Add(p27);
            dbcontext.Add(p28);
            dbcontext.Add(p29);
            dbcontext.Add(p30);
            dbcontext.Add(p31);
            dbcontext.SaveChanges();

            //seed collection point
            CollectionPoint c1 = new CollectionPoint("Stationary Store", "9:30AM");
            CollectionPoint c2 = new CollectionPoint("Management School", "11:30AM");
            CollectionPoint c3 = new CollectionPoint("Medical School", "9:30AM");
            CollectionPoint c4 = new CollectionPoint("English School", "11:30AM");
            CollectionPoint c5 = new CollectionPoint("Science School", "9:30AM");
            CollectionPoint c6 = new CollectionPoint("University Hospital", "11:30AM");
            dbcontext.Add(c1);
            dbcontext.Add(c2);
            dbcontext.Add(c3);
            dbcontext.Add(c4);
            dbcontext.Add(c5);
            dbcontext.Add(c6);
            dbcontext.SaveChanges();

            //seed department
            Department d1 = new Department("STOR", "LU Stationary Store", 9999999);
            d1.CollectionPointId = 6;
            Department d2 = new Department("ENGL", "English Dept", 8742234);
            d2.CollectionPointId = 5;
            Department d3 = new Department("CPSC", "Computer Science", 8901235);
            d3.CollectionPointId = 2;
            Department d4 = new Department("COMM", "Commerce Dept", 8741284);
            d4.CollectionPointId = 5;
            Department d5 = new Department("REGR", "Registrar Dept", 8901266);
            d5.CollectionPointId = 1;
            Department d6 = new Department("ZOOL", " Zoology Dept", 8901266);
            d6.CollectionPointId = 2;
            dbcontext.Add(d1);
            dbcontext.Add(d2);
            dbcontext.Add(d3);
            dbcontext.Add(d4);
            dbcontext.Add(d5);
            dbcontext.Add(d6);
            dbcontext.SaveChanges();

            //seed employee
            Employee e1 = new Employee("Esther (sc)", "Estherlu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "STOR", "sc");
            dbcontext.Add(e1);

            dbcontext.SaveChanges();
            Employee e2 = new Employee("Peter (ss)", "Peterlu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "STOR", "ss");
            dbcontext.Add(e2);
            dbcontext.SaveChanges();
            Employee e3 = new Employee("James (sm)", "Jameslu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "STOR", "sm");
            dbcontext.Add(e3);
            dbcontext.SaveChanges();
            Employee e4 = new Employee("Pamela Kow(de)", "Pamelalu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "ENGL", "de");
            dbcontext.Add(e4);
            dbcontext.SaveChanges();
            Employee e5 = new Employee("Elizabeth Tan(dh)", "Elizabethlu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "ENGL", "dh");
            dbcontext.Add(e5);
            dbcontext.SaveChanges();
            Employee e6 = new Employee("Wee Kian Fatt(de)", "KianFattlu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "ENGL", "de");
            dbcontext.Add(e6);
            dbcontext.SaveChanges();
            Employee e7 = new Employee("Soh Kian Wee(dh)", "kianweelu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "CPSC", "dh");
            dbcontext.Add(e7);
            dbcontext.SaveChanges();
            Employee e8 = new Employee("Mary Tan(de)", "Marylu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "COMM", "de");
            dbcontext.Add(e8);
            dbcontext.SaveChanges();
            Employee e9 = new Employee("Nasi Lemak(dh)", "Nasilemaklu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "COMM", "dh");
            dbcontext.Add(e9);
            dbcontext.SaveChanges();
            Employee e10 = new Employee("Lor Mee(de)", "Lormeelu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "REGR", "de");
            dbcontext.Add(e10);
            dbcontext.SaveChanges();
            Employee e11 = new Employee("Carrot Cake(dh)", "Carrotcakelu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "REGR", "dh");
            dbcontext.Add(e11);
            dbcontext.SaveChanges();
            Employee e12 = new Employee("Fish Ball(de)", "Fishballlu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "ZOOL", "de");
            dbcontext.Add(e12);
            dbcontext.SaveChanges();
            Employee e13 = new Employee("Cheong Fun(dh)", "Cheongfunlu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "ZOOL", "dh");
            dbcontext.Add(e13);
            dbcontext.SaveChanges();
            Employee e14 = new Employee("Adeline Yee(de)", "Adelinelu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "ENGL", "de");
            dbcontext.Add(e14);
            dbcontext.SaveChanges();
            Employee e15 = new Employee("Nicole Chong(de)", "Nicolelu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "CPSC", "de");
            dbcontext.Add(e15);
            dbcontext.SaveChanges();
            Employee e16 = new Employee("Fel(sc)", "Fellu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "STOR", "sc");
            dbcontext.Add(e16);
            dbcontext.SaveChanges();

            //set manager to employee
            e4.ManagerId = 5;
            e14.ManagerId = 5;
            e6.ManagerId = 5;
            e15.ManagerId = 7;
            e8.ManagerId = 9;
            e10.ManagerId = 11;
            e12.ManagerId = 13;
            e1.ManagerId = 2;
            e2.ManagerId = 3;
            e16.ManagerId = 2;
            dbcontext.Update(e1);
            dbcontext.Update(e4);
            dbcontext.Update(e6);
            dbcontext.Update(e8);
            dbcontext.Update(e10);
            dbcontext.Update(e12);
            dbcontext.Update(e14);
            dbcontext.Update(e15);
            dbcontext.Update(e16);
            dbcontext.SaveChanges();
            //set department head and employee

            d2.RepId = 6;
            d2.HeadId = 5;
            d3.RepId = 15;
            d3.HeadId = 7;
            d4.RepId = 8;
            d4.HeadId = 9;
            d5.RepId = 10;
            d5.HeadId = 11;
            d6.RepId = 12;
            d6.HeadId = 13;


            dbcontext.Update(d2);
            dbcontext.Update(d3);
            dbcontext.Update(d4);
            dbcontext.Update(d5);
            dbcontext.Update(d6);
            dbcontext.SaveChanges();

            //seed supplier
            //public Supplier(string Id, string Name, string ContactPersonName, int PhoneNo, int? FaxNo, string Address, string? GstRegNo, string Email)
            Supplier supplier1 = new Supplier("ALPA", "ALPHA Office Supplies", "Ms Irene Tan", 4619928, 4612238, "Blk 1128, Ang Mo Kio Industrial Park, #02-1108 Ang Mo Kio Street 62,Singapore 622262", "MR -8500440-2", "aalpa@mailinator.com");
            Supplier supplier2 = new Supplier("CHEP", "Cheap Stationer", "Mr Soh Kway Koh", 3543234, 4742434, "Blk 34, Clementi Road, #07-02 Ban Ban Soh Building, Singapore 110525", null, "cchep@mailinator.com");
            Supplier supplier3 = new Supplier("BANE", "BANES Shop", "Mr Loh Ah Pek", 4781234, 47924344, "Blk 124, Alexandra Road, #03-04 Banes Building, Singapore 550315", "MR-8200420-2", "bbanes@mailinator.com");
            Supplier supplier4 = new Supplier("OMEG", "OMEGA Stationery Supplier", "Mr Ronnie Ho", 767233, 7671234, "Blk 11, Hillview Avenue, #03-04 , Singapore 679036", "MR-8555330-1", "oomega@mailinator.com");
            dbcontext.Add(supplier1);
            dbcontext.Add(supplier2);
            dbcontext.Add(supplier3);
            dbcontext.Add(supplier4);
            dbcontext.SaveChanges();


            //seed tender quotation
            // public TenderQuotation(string SupplierId, int Year, string ProductId, string PricePerUom,int? Rank)
            //TenderQuotation tq1 = new TenderQuotation("BANE", 2020, "P043", 1.00,"Dozen", 1); //Bane-2020-pencial with eraser head, 1,$1
            //TenderQuotation tq2 = new TenderQuotation("ALPA", 2020, "C001", 2.00,"Dozen", 1);//ALPA-2020-Clip-1,$2
            //TenderQuotation tq3 = new TenderQuotation("AlPA", 2020, "P043", 1.00,"Dozen", 2);
            //TenderQuotation tq4 = new TenderQuotation("BANE", 2020, "C001", 2.20,"Dozen", 2);
            //TenderQuotation tq5 = new TenderQuotation("CHEP", 2020, "C001", 2.50,"Dozen", 3);
            //TenderQuotation tq6 = new TenderQuotation("CHEP", 2020, "P043", 1.20,"Dozen", 3);
            //TenderQuotation tq7 = new TenderQuotation("OMEG", 2020, "C001", 2.75,"Dozen", null);
            //TenderQuotation tq8 = new TenderQuotation("OMEG", 2020, "P043", 1.75,"Dozen", null);
            //TenderQuotation tq9 = new TenderQuotation("OMEG", 2020, "D001", 10.00,"Box", 1); //diskettes ,$10
            //TenderQuotation tq10 = new TenderQuotation("CHEP", 2020, "D001",10.10,"Box", 2);
            //dbcontext.Add(tq1);
            //dbcontext.Add(tq2);
            //dbcontext.Add(tq3);
            //dbcontext.Add(tq4);
            //dbcontext.Add(tq5);
            //dbcontext.Add(tq6);
            //dbcontext.Add(tq7);
            //dbcontext.Add(tq8);
            //dbcontext.Add(tq9);
            //dbcontext.Add(tq10);
            //dbcontext.SaveChanges();


            //TenderQuotation tq11 = new TenderQuotation("BANE", 2020, "D001", 10.20,"Box", 3);
            //TenderQuotation tq12 = new TenderQuotation("CHEP", 2020, "E032", 1.00,"Each", 1);//exercise book,$1
            //TenderQuotation tq13 = new TenderQuotation("ALPA", 2020, "D001", 1.05,"Box", 2);
            //TenderQuotation tq14 = new TenderQuotation("OMEG", 2020, "D001", 1.10,"Box", 3);
            //TenderQuotation tq15 = new TenderQuotation("ALPA", 2020, "E032", 1.05,"EACH", 2);
            //TenderQuotation tq16 = new TenderQuotation("BANE", 2020, "E032", 1.10,"EACH", 3);

            ///* TO BE KEPT */
            //TenderQuotation tq17 = new TenderQuotation("OMEG", 2020, "H011", 10, "Box", 1);
            //TenderQuotation tq18 = new TenderQuotation("ALPA", 2020, "H011", 10.50, "Box", 2);
            //TenderQuotation tq19 = new TenderQuotation("BANE", 2020, "H011", 11.00, "Box", 3);

            //TenderQuotation tq20 = new TenderQuotation("OMEG", 2020, "H012", 10, "Box", 1);
            //TenderQuotation tq21 = new TenderQuotation("ALPA", 2020, "H012", 11, "Box", 2);
            //TenderQuotation tq22 = new TenderQuotation("BANE", 2020, "H012", 12, "Box", 3);

            //dbcontext.Add(tq11);
            //dbcontext.Add(tq12);
            //dbcontext.Add(tq13);
            //dbcontext.Add(tq14);
            //dbcontext.Add(tq15);
            //dbcontext.Add(tq16);
            //dbcontext.SaveChanges();






            //Product p1 = new Product("C001", "Clips Double 1", 1, 15, 15, "Dozen");
            TenderQuotation q1a = new TenderQuotation("OMEG", 2020, "C001", 10, "Dozen", 1);
            TenderQuotation q1b = new TenderQuotation("ALPA", 2020, "C001", 10.50, "Dozen", 2);
            TenderQuotation q1c= new TenderQuotation("BANE", 2020, "C001", 11.00, "Dozen", 3);
            TenderQuotation q1d = new TenderQuotation("CHEP", 2020, "C001", 11.00, "Dozen", null);
            dbcontext.Add(q1a);
            dbcontext.Add(q1b);
            dbcontext.Add(q1c);

            dbcontext.Add(q1d);

            //Product p2 = new Product("C002", "Clips Double 2", 1, 30, 50, "Dozen");
            TenderQuotation q2a = new TenderQuotation("OMEG", 2020, "C002", 10, "Dozen", 1);
            TenderQuotation q2b = new TenderQuotation("ALPA", 2020, "C002", 10.50, "Dozen", 2);
            TenderQuotation q2c = new TenderQuotation("BANE", 2020, "C002", 11.00, "Dozen", 3);
            TenderQuotation q2d = new TenderQuotation("CHEP", 2020, "C002", 11.00, "Dozen", null);
            dbcontext.Add(q2a);
            dbcontext.Add(q2b);
            dbcontext.Add(q2c);
            dbcontext.Add(q2d);


            //Product p3 = new Product("C003", "Clips Double 3/4", 1, 15, 15, "Dozen");
            TenderQuotation q3a = new TenderQuotation("OMEG", 2020, "C003", 10, "Dozen", 1);
            TenderQuotation q3b = new TenderQuotation("ALPA", 2020, "C003", 10.50, "Dozen", 2);
            TenderQuotation q3c = new TenderQuotation("BANE", 2020, "C003", 11.00, "Dozen", 3);
            TenderQuotation q3d = new TenderQuotation("CHEP", 2020, "C003", 11.00, "Dozen", null);
            dbcontext.Add(q3a);
            dbcontext.Add(q3b);
            dbcontext.Add(q3c);
            dbcontext.Add(q3d);


            //Product p4 = new Product("C004", "Clips Paper Large", 1, 15, 15, "Box");
            TenderQuotation q4a = new TenderQuotation("OMEG", 2020, "C004", 10, "Box", 1);
            TenderQuotation q4b = new TenderQuotation("ALPA", 2020, "C004", 10.50, "Box", 2);
            TenderQuotation q4c = new TenderQuotation("BANE", 2020, "C004", 11.00, "Box", 3);
            TenderQuotation q4d = new TenderQuotation("CHEP", 2020, "C004", 11.00, "Box", null);
            dbcontext.Add(q4a);
            dbcontext.Add(q4b);
            dbcontext.Add(q4c);
            dbcontext.Add(q4d);

            //Product p5 = new Product("E001", "Envelop Brown (3'x6')", 2, 100, 100, "Each");
            TenderQuotation q5a = new TenderQuotation("OMEG", 2020, "E001", 10, "Each", 1);
            TenderQuotation q5b = new TenderQuotation("ALPA", 2020, "E001", 10.50, "Each", 2);
            TenderQuotation q5c = new TenderQuotation("BANE", 2020, "E001", 11.00, "Each", 3);
            TenderQuotation q5d = new TenderQuotation("CHEP", 2020, "E001", 11.00, "Each", null);
            dbcontext.Add(q5a);
            dbcontext.Add(q5b);
            dbcontext.Add(q5c);
            dbcontext.Add(q5d);

            //Product p6 = new Product("E002", "Envelop Brown (3'x6') w/Window", 2, 100, 100, "Each");
            TenderQuotation q6a = new TenderQuotation("OMEG", 2020, "E002", 10, "Each", 1);
            TenderQuotation q6b = new TenderQuotation("ALPA", 2020, "E002", 10.50, "Each", 2);
            TenderQuotation q6c = new TenderQuotation("BANE", 2020, "E002", 11.00, "Each", 3);
            TenderQuotation q6d = new TenderQuotation("CHEP", 2020, "E002", 11.00, "Each", null);
            dbcontext.Add(q6a);
            dbcontext.Add(q6b);
            dbcontext.Add(q6c);
            dbcontext.Add(q6d);

            //Product p7 = new Product("E003", "Envelop Brown (6'x7')", 2, 100, 100, "Each");
            TenderQuotation q7a = new TenderQuotation("OMEG", 2020, "E003", 10, "Each", 1);
            TenderQuotation q7b = new TenderQuotation("ALPA", 2020, "E003", 10.50, "Each", 2);
            TenderQuotation q7c = new TenderQuotation("BANE", 2020, "E003", 11.00, "Each", 3);
            TenderQuotation q7d = new TenderQuotation("CHEP", 2020, "E003", 11.00, "Each", null);
            dbcontext.Add(q7a);
            dbcontext.Add(q7b);
            dbcontext.Add(q7c);
            dbcontext.Add(q7d);

            //Product p8 = new Product("E004", "Envelop Brown (6'x7') w/Window", 2, 100, 100, "Each");
            TenderQuotation q8a = new TenderQuotation("OMEG", 2020, "E004", 10, "Each", 1);
            TenderQuotation q8b = new TenderQuotation("ALPA", 2020, "E004", 10.50, "Each", 2);
            TenderQuotation q8c = new TenderQuotation("BANE", 2020, "E004", 11.00, "Each", 3);
            TenderQuotation q8d = new TenderQuotation("CHEP", 2020, "E004", 11.00, "Each", null);
            dbcontext.Add(q8a);
            dbcontext.Add(q8b);
            dbcontext.Add(q8c);
            dbcontext.Add(q8d);

            //Product p9 = new Product("E020", "Eraser (hard)", 3, 20, 50, "Each");
            TenderQuotation q9a = new TenderQuotation("OMEG", 2020, "E020", 10, "Each", 1);
            TenderQuotation q9b = new TenderQuotation("ALPA", 2020, "E020", 10.50, "Each", 2);
            TenderQuotation q9c = new TenderQuotation("BANE", 2020, "E020", 11.00, "Each", 3);
            TenderQuotation q9d = new TenderQuotation("CHEP", 2020, "E020", 11.00, "Each", null);
            dbcontext.Add(q9a);
            dbcontext.Add(q9b);
            dbcontext.Add(q9c);
            dbcontext.Add(q9d);

            //Product p10 = new Product("E021", "Eraser (soft)", 3, 20, 50, "Each");
            TenderQuotation q10a = new TenderQuotation("OMEG", 2020, "E021", 10, "Each", 1);
            TenderQuotation q10b = new TenderQuotation("ALPA", 2020, "E021", 10.50, "Each", 2);
            TenderQuotation q10c = new TenderQuotation("BANE", 2020, "E021", 11.00, "Each", 3);
            TenderQuotation q10d = new TenderQuotation("CHEP", 2020, "E021", 11.00, "Each", null);
            dbcontext.Add(q10a);
            dbcontext.Add(q10b);
            dbcontext.Add(q10c);
            dbcontext.Add(q10d);

            //Product p11 = new Product("E030", "Exercise Book (100pg)", 4, 100, 100, "Each");
            TenderQuotation q11a = new TenderQuotation("OMEG", 2020, "E030", 10, "Each", 1);
            TenderQuotation q11b = new TenderQuotation("ALPA", 2020, "E030", 10.50, "Each", 2);
            TenderQuotation q11c = new TenderQuotation("BANE", 2020, "E030", 11.00, "Each", 3);
            TenderQuotation q11d = new TenderQuotation("CHEP", 2020, "E030", 11.00, "Each", null);
            dbcontext.Add(q11a);
            dbcontext.Add(q11b);
            dbcontext.Add(q11c);
            dbcontext.Add(q11d);


            //Product p12 = new Product("E031", "Exercise Book (120pg)", 4, 100, 100, "Each");
            TenderQuotation q12a = new TenderQuotation("OMEG", 2020, "E031", 10, "Each", 1);
            TenderQuotation q12b = new TenderQuotation("ALPA", 2020, "E031", 10.50, "Each", 2);
            TenderQuotation q12c = new TenderQuotation("BANE", 2020, "E031", 11.00, "Each", 3);
            TenderQuotation q12d = new TenderQuotation("CHEP", 2020, "E031", 11.00, "Each", null);
            dbcontext.Add(q12a);
            dbcontext.Add(q12b);
            dbcontext.Add(q12c);
            dbcontext.Add(q12d);

            //Product p13 = new Product("E032", "Exercise Book A4 Hardcover (100 pg)", 4, 100, 100, "Each");
            TenderQuotation q13a = new TenderQuotation("OMEG", 2020, "E032", 10, "Each", 1);
            TenderQuotation q13b = new TenderQuotation("ALPA", 2020, "E032", 10.50, "Each", 2);
            TenderQuotation q13c = new TenderQuotation("BANE", 2020, "E032", 11.00, "Each", 3);
            TenderQuotation q13d = new TenderQuotation("CHEP", 2020, "E032", 11.00, "Each", null);
            dbcontext.Add(q13a);
            dbcontext.Add(q13b);
            dbcontext.Add(q13c);
            dbcontext.Add(q13d);

            //Product p14 = new Product("E033", "Exercise Book A5 Hardcover (120 pg)", 4, 100, 100, "Each");
            TenderQuotation q14a = new TenderQuotation("OMEG", 2020, "E033", 10, "Each", 1);
            TenderQuotation q14b = new TenderQuotation("ALPA", 2020, "E033", 10.50, "Each", 2);
            TenderQuotation q14c = new TenderQuotation("BANE", 2020, "E033", 11.00, "Each", 3);
            TenderQuotation q14d = new TenderQuotation("CHEP", 2020, "E033", 11.00, "Each", null);
            dbcontext.Add(q14a);
            dbcontext.Add(q14b);
            dbcontext.Add(q14c);
            dbcontext.Add(q14d);

            //Product p15 = new Product("F020", "File Separator", 5, 50, 100, "Set");
            TenderQuotation q15a = new TenderQuotation("OMEG", 2020, "F020", 10, "Each", 1);
            TenderQuotation q15b = new TenderQuotation("ALPA", 2020, "F020", 10.50, "Each", 2);
            TenderQuotation q15c = new TenderQuotation("BANE", 2020, "F020", 11.00, "Each", 3);
            TenderQuotation q15d = new TenderQuotation("CHEP", 2020, "F020", 11.00, "Each", null);
            dbcontext.Add(q15a);
            dbcontext.Add(q15b);
            dbcontext.Add(q15c);
            dbcontext.Add(q15d);

            //Product p16 = new Product("F021", "File-Blue Plain", 5, 50, 100, "Each");
            TenderQuotation q16a = new TenderQuotation("OMEG", 2020, "F021", 10, "Each", 1);
            TenderQuotation q16b = new TenderQuotation("ALPA", 2020, "F021", 10.50, "Each", 2);
            TenderQuotation q16c = new TenderQuotation("BANE", 2020, "F021", 11.00, "Each", 3);
            TenderQuotation q16d = new TenderQuotation("CHEP", 2020, "F021", 11.00, "Each", null);
            dbcontext.Add(q16a);
            dbcontext.Add(q16b);
            dbcontext.Add(q16c);
            dbcontext.Add(q16d);

            //Product p17 = new Product("F022", "File-Blue with Logo", 5, 100, 200, "Each");
            TenderQuotation q17a = new TenderQuotation("OMEG", 2020, "F022", 10, "Each", 1);
            TenderQuotation q17b = new TenderQuotation("ALPA", 2020, "F022", 10.50, "Each", 2);
            TenderQuotation q17c = new TenderQuotation("BANE", 2020, "F022", 11.00, "Each", 3);
            TenderQuotation q17d = new TenderQuotation("CHEP", 2020, "F022", 11.00, "Each", null);
            dbcontext.Add(q17a);
            dbcontext.Add(q17b);
            dbcontext.Add(q17c);
            dbcontext.Add(q17d);

            //Product p18 = new Product("F023", "File-Brown w/o Logo", 5, 100, 200, "Each");
            TenderQuotation q18a = new TenderQuotation("OMEG", 2020, "F023", 10, "Each", 1);
            TenderQuotation q18b = new TenderQuotation("ALPA", 2020, "F023", 10.50, "Each", 2);
            TenderQuotation q18c = new TenderQuotation("BANE", 2020, "F023", 11.00, "Each", 3);
            TenderQuotation q18d = new TenderQuotation("CHEP", 2020, "F023", 11.00, "Each", null);
            dbcontext.Add(q18a);
            dbcontext.Add(q18b);
            dbcontext.Add(q18c);
            dbcontext.Add(q18d);

            //Product p19 = new Product("H011", "Highlighter Blue", 6, 80, 100, "Box");//pen
            TenderQuotation q19a = new TenderQuotation("OMEG", 2020, "H011", 10, "Box", 1);
            TenderQuotation q19b = new TenderQuotation("ALPA", 2020, "H011", 10.50, "Box", 2);
            TenderQuotation q19c = new TenderQuotation("BANE", 2020, "H011", 11.00, "Box", 3);
            TenderQuotation q19d = new TenderQuotation("CHEP", 2020, "H011", 11.00, "Box", null);
            dbcontext.Add(q19a);
            dbcontext.Add(q19b);
            dbcontext.Add(q19c);
            dbcontext.Add(q19d);

            //Product p20 = new Product("H012", "Highlighter Green", 6, 80, 100, "Box");
            TenderQuotation q20a = new TenderQuotation("OMEG", 2020, "H012", 10, "Box", 1);
            TenderQuotation q20b = new TenderQuotation("ALPA", 2020, "H012", 11, "Box", 2);
            TenderQuotation q20c = new TenderQuotation("BANE", 2020, "H012", 12, "Box", 3);
            TenderQuotation q20d = new TenderQuotation("CHEP", 2020, "H012", 11.00, "Box", null);
            dbcontext.Add(q20a);
            dbcontext.Add(q20b);
            dbcontext.Add(q20c);
            dbcontext.Add(q20d);

            //Product p21 = new Product("H013", "Highlighter Pink", 6, 80, 100, "Box");
            TenderQuotation q21a = new TenderQuotation("OMEG", 2020, "H013", 10, "Box", 1);
            TenderQuotation q21b = new TenderQuotation("ALPA", 2020, "H013", 11, "Box", 2);
            TenderQuotation q21c = new TenderQuotation("BANE", 2020, "H013", 12, "Box", 3);
            TenderQuotation q21d = new TenderQuotation("CHEP", 2020, "H013", 11.00, "Box", null);
            dbcontext.Add(q21a);
            dbcontext.Add(q21b);
            dbcontext.Add(q21c);
            dbcontext.Add(q21d);

            //Product p22 = new Product("H014", "Highlighter Yellow", 6, 80, 100, "Box");
            TenderQuotation q22a = new TenderQuotation("OMEG", 2020, "H014", 10, "Box", 1);
            TenderQuotation q22b = new TenderQuotation("ALPA", 2020, "H014", 11, "Box", 2);
            TenderQuotation q22c = new TenderQuotation("BANE", 2020, "H014", 12, "Box", 3);
            TenderQuotation q22d = new TenderQuotation("CHEP", 2020, "H014", 11.00, "Box", null);
            dbcontext.Add(q22a);
            dbcontext.Add(q22b);
            dbcontext.Add(q22c);
            dbcontext.Add(q22d);

            //Product p23 = new Product("H031", "Hole Puncher 2 holes", 7, 20, 50, "Each");
            TenderQuotation q23a = new TenderQuotation("OMEG", 2020, "H031", 10, "Each", 1);
            TenderQuotation q23b = new TenderQuotation("ALPA", 2020, "H031", 11, "Each", 2);
            TenderQuotation q23c = new TenderQuotation("BANE", 2020, "H031", 12, "Each", 3);
            TenderQuotation q23d = new TenderQuotation("CHEP", 2020, "H031", 11.00, "Each", null);
            dbcontext.Add(q23a);
            dbcontext.Add(q23b);
            dbcontext.Add(q23c);
            dbcontext.Add(q23d);

            //Product p24 = new Product("H032", "Hole Puncher 3 holes", 7, 20, 50, "Each");
            TenderQuotation q24a = new TenderQuotation("OMEG", 2020, "H032", 10, "Each", 1);
            TenderQuotation q24b = new TenderQuotation("ALPA", 2020, "H032", 11, "Each", 2);
            TenderQuotation q24c = new TenderQuotation("BANE", 2020, "H032", 12, "Each", 3);
            TenderQuotation q24d = new TenderQuotation("CHEP", 2020, "H032", 11.00, "Each", null);
            dbcontext.Add(q24a);
            dbcontext.Add(q24b);
            dbcontext.Add(q24c);
            dbcontext.Add(q24d);

            //Product p25 = new Product("H033", "Hole Puncher Adjustable", 7, 20, 50, "Each");
            TenderQuotation q25a = new TenderQuotation("OMEG", 2020, "H033", 10, "Each", 1);
            TenderQuotation q25b = new TenderQuotation("ALPA", 2020, "H033", 11, "Each", 2);
            TenderQuotation q25c = new TenderQuotation("BANE", 2020, "H033", 12, "Each", 3);
            TenderQuotation q25d = new TenderQuotation("CHEP", 2020, "H033", 11.00, "Each", null);
            dbcontext.Add(q25a);
            dbcontext.Add(q25b);
            dbcontext.Add(q25c);
            dbcontext.Add(q25d);

            //Product p26 = new Product("P010", "Pad Postit Memo 1'x2'", 8, 60, 100, "Packet");//8=pad
            TenderQuotation q26a = new TenderQuotation("OMEG", 2020, "P010", 10, "Packet", 1);
            TenderQuotation q26b = new TenderQuotation("ALPA", 2020, "P010", 11, "Packet", 2);
            TenderQuotation q26c = new TenderQuotation("BANE", 2020, "P010", 12, "Packet", 3);
            TenderQuotation q26d = new TenderQuotation("CHEP", 2020, "P010", 11.00, "Packet", null);
            dbcontext.Add(q26a);
            dbcontext.Add(q26b);
            dbcontext.Add(q26c);
            dbcontext.Add(q26d);

            //Product p27 = new Product("P011", "Pad Postit Memo 1/2'x1'", 8, 60, 100, "Packet");
            TenderQuotation q27a = new TenderQuotation("OMEG", 2020, "P011", 10, "Packet", 1);
            TenderQuotation q27b = new TenderQuotation("ALPA", 2020, "P011", 11, "Packet", 2);
            TenderQuotation q27c = new TenderQuotation("BANE", 2020, "P011", 12, "Packet", 3);
            TenderQuotation q27d = new TenderQuotation("CHEP", 2020, "P011", 11.00, "Packet", null);
            dbcontext.Add(q27a);
            dbcontext.Add(q27b);
            dbcontext.Add(q27c);
            dbcontext.Add(q27d);

            //Product p28 = new Product("P012", "Pad Postit Memo 1/2'x2'", 8, 60, 100, "Packet");
            TenderQuotation q28a = new TenderQuotation("OMEG", 2020, "P012", 10, "Packet", 1);
            TenderQuotation q28b = new TenderQuotation("ALPA", 2020, "P012", 11, "Packet", 2);
            TenderQuotation q28c = new TenderQuotation("BANE", 2020, "P012", 12, "Packet", 3);
            TenderQuotation q28d = new TenderQuotation("CHEP", 2020, "P012", 11.00, "Packet", null);
            dbcontext.Add(q28a);
            dbcontext.Add(q28b);
            dbcontext.Add(q28c);
            dbcontext.Add(q28d);

            //Product p29 = new Product("P013", "Pad Postit Memo 2'x3'", 8, 60, 100, "Packet");
            TenderQuotation q29a = new TenderQuotation("OMEG", 2020, "P013", 10, "Packet", 1);
            TenderQuotation q29b = new TenderQuotation("ALPA", 2020, "P013", 11, "Packet", 2);
            TenderQuotation q29c = new TenderQuotation("BANE", 2020, "P013", 12, "Packet", 3);
            TenderQuotation q29d = new TenderQuotation("CHEP", 2020, "P013", 11.00, "Packet", null);
            dbcontext.Add(q29a);
            dbcontext.Add(q29b);
            dbcontext.Add(q29c);
            dbcontext.Add(q29d);

            //Product p30 = new Product("P043", "Pencil 2b with Eraser End", 6, 100, 500, "Dozen");
            TenderQuotation q30a = new TenderQuotation("OMEG", 2020, "P043", 10, "Dozen", 1);
            TenderQuotation q30b = new TenderQuotation("ALPA", 2020, "P043", 11, "Dozen", 2);
            TenderQuotation q30c = new TenderQuotation("BANE", 2020, "P043", 12, "Dozen", 3);
            TenderQuotation q30d = new TenderQuotation("CHEP", 2020, "P043", 11.00, "Dozen", null);
            dbcontext.Add(q30a);
            dbcontext.Add(q30b);
            dbcontext.Add(q30c);
            dbcontext.Add(q30d);

            //Product p31 = new Product("D001", "Diskettes 3.5 inch (HD)", 19, 20, 30, "Box");
            TenderQuotation q31a = new TenderQuotation("OMEG", 2020, "D001", 10, "Box", 1);
            TenderQuotation q31b = new TenderQuotation("ALPA", 2020, "D001", 11, "Box", 2);
            TenderQuotation q31c = new TenderQuotation("BANE", 2020, "D001", 12, "Box", 3);
            TenderQuotation q31d = new TenderQuotation("CHEP", 2020, "D001", 11.00, "Box", null);
            dbcontext.Add(q31a);
            dbcontext.Add(q31b);
            dbcontext.Add(q31c);
            dbcontext.Add(q31d);


            dbcontext.SaveChanges();






            //seed transaction
            //public Transaction(string ProductId, DateTime Date, string Description, int Qty, int Balance, int UpdatedByEmpId, string? RefCode)

            //corr/to retr1

            Transaction t1 = new Transaction("C001", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t2 = new Transaction("C002", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t3 = new Transaction("C003", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t4 = new Transaction("C004", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t5 = new Transaction("E001", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t6 = new Transaction("E002", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t7 = new Transaction("E003", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t8 = new Transaction("E004", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t9 = new Transaction("E020", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t10 = new Transaction("E021", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t11 = new Transaction("E030", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t12 = new Transaction("E031", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t13 = new Transaction("E032", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t14 = new Transaction("E033", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t15 = new Transaction("F020", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t16 = new Transaction("F021", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t17 = new Transaction("F022", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t18 = new Transaction("F023", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t19 = new Transaction("H011", 1577836800000, "Inital transaction record", 0, 10, 1, "init001");
            Transaction t20 = new Transaction("H012", 1577836800000, "Inital transaction record", 0, 10, 1, "init001");
            Transaction t21 = new Transaction("H013", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t22 = new Transaction("H014", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t23 = new Transaction("H031", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t24 = new Transaction("H032", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t25 = new Transaction("H033", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t26 = new Transaction("P010", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t27 = new Transaction("P011", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t28 = new Transaction("P012", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t29 = new Transaction("P013", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t30 = new Transaction("P043", 1577836800000, "Inital transaction record", 0, 1000, 1, "init001");
            Transaction t31 = new Transaction("D001", 1577836800000, "Inital transaction record", 0, 30, 1, "init001");
            dbcontext.Add(t1);
            dbcontext.Add(t2);
            dbcontext.Add(t3);
            dbcontext.Add(t4);
            dbcontext.Add(t5);
            dbcontext.Add(t6);
            dbcontext.Add(t7);
            dbcontext.Add(t8);
            dbcontext.Add(t9);
            dbcontext.Add(t10);
            dbcontext.Add(t11);
            dbcontext.Add(t12);
            dbcontext.Add(t13);
            dbcontext.Add(t14);
            dbcontext.Add(t15);
            dbcontext.Add(t16);
            dbcontext.Add(t17);
            dbcontext.Add(t18);
            dbcontext.Add(t19);
            dbcontext.Add(t20);
            dbcontext.Add(t21);
            dbcontext.Add(t22);
            dbcontext.Add(t23);
            dbcontext.Add(t24);
            dbcontext.Add(t25);
            dbcontext.Add(t26);
            dbcontext.Add(t27);
            dbcontext.Add(t28);
            dbcontext.Add(t29);
            dbcontext.Add(t30);
            dbcontext.Add(t31);
            dbcontext.SaveChanges();

            Transaction trans3 = new Transaction("C001", 1594724400000, "supply from ALPA", 15, 1015, 1, null); //14/7/2020 @ 11:00am (UTC)
            dbcontext.Add(trans3);
            dbcontext.SaveChanges();
            Transaction trans4 = new Transaction("C001", 1595237400000, "Supply to Computing Department", -10, 1005, 1, null); //20/7/2020@9:30am
            dbcontext.Add(trans4);
            dbcontext.SaveChanges();
            Transaction trans5 = new Transaction("C001", 1595237400000, "supply to English Department", -50, 955, 1, null);//"2 spoilt in stock"; 20/7/2020 @ 9:30am (UTC)
            dbcontext.Add(trans5);
            dbcontext.SaveChanges();
            Transaction trans6 = new Transaction("C001", 1595926800000, "Supply from ALPA", 30, 985, 16, null);//29/7/2020 @ 9:30am (UTC)
            dbcontext.Add(trans6);
            dbcontext.SaveChanges();
            Transaction trans8 = new Transaction("C001", 1596443400000, "stock adjustment 031/007/2020", -2, 983, 1, null); //3/8/2020 @ 8:300am (UTC)
            dbcontext.Add(trans8);
            dbcontext.SaveChanges();
            Transaction trans12 = new Transaction("C001", 1597060800000, "Supply to Computing Department", -10, 973, 1, null); //10/8/2020 @ 12:00pm (UTC)
            dbcontext.Add(trans12);
            dbcontext.SaveChanges();
            Transaction trans13 = new Transaction("C001", 1597060800000, "supply to English Department", -8, 965, 16, null);//10/8/2020 @ 12:00pm (UTC)
            dbcontext.Add(trans13);
            dbcontext.SaveChanges();

            Transaction trans2 = new Transaction("D001", 1594724400000, "supply to English Department", -6, 20, 1, null);  //14/7/2020 @ 11:00am (UTC)
            dbcontext.Add(trans2);
            dbcontext.SaveChanges();

            Transaction trans1 = new Transaction("E032", 1594724400000, "supply from ALPHA", 40, 1040, 1, null);//14/7/2020 @ 11:00am (UTC)
            dbcontext.Add(trans1);
            dbcontext.SaveChanges();

            //corr/to retr2
            Transaction trans7 = new Transaction("P043", 1596441600000, "supply from supplier Bane", 50, 1050, 1, null);//3/8 / 2020 @ 8:00am(UTC)
            dbcontext.Add(trans7);
            dbcontext.SaveChanges();
            Transaction trans9 = new Transaction("P043", 1596447000000, "supply to English Department", -20, 1030, 1, null); //3/8/2020 @ 9:300am (UTC)
            dbcontext.Add(trans9);
            dbcontext.SaveChanges();
            //corr/to retr3
            Transaction trans10 = new Transaction("P043", 1597060800000, "Supply to Computing Department", -30, 1000, 16, null); //10/8/2020 @ 12:00pm (UTC)
            dbcontext.Add(trans10);
            dbcontext.SaveChanges();
            Transaction trans11 = new Transaction("P043", 1597060800000, "Supply to English Department", -50, 950, 16, null);//10/8/2020 @ 12:00pm (UTC)
            dbcontext.Add(trans11);
            dbcontext.SaveChanges();
            
            


            //seed retrieval(Fri)
            //public Retrieval(int ClerkId, long? DisbursedDate, long? RetrievedDate, string Status,
            //    string? RetrievalComment, bool? NeedAdjustment)

            //Fri 17/7/2020 @2:00pm to retrieve, disbursement on 20/7, item C001 to both ENGL and CPSC
            //(cover 2 rows in ReqDet)
            
            Retrieval retr1 = new Retrieval(1, 1595237400000, 1594994400000, Status.RetrievalStatus.retrieved);
            dbcontext.Add(retr1);
            dbcontext.SaveChanges();
            //Fri 31/7/2020 @3:00 to retrive, disbursement on 3/8,item "P043" to ENGL (cover 1 rows in ReqDet)
            Retrieval retr2 = new Retrieval(1, 1596447000000, 1596207600000, Status.RetrievalStatus.retrieved);
            dbcontext.Add(retr2);
            dbcontext.SaveChanges();
            //Fri 7//8/2020 @3:00 to retrive, disbursement on 10/8,item "P043" and "C001" to ENGL and CPSC(cover 4 rows in ReqDet)
            Retrieval retr3 = new Retrieval(1, 1597060800000, 1596812400000, Status.RetrievalStatus.retrieved, "2 clips in inventory found rusty, spoilt", true);
            dbcontext.Add(retr3);
            dbcontext.SaveChanges();

            Retrieval retr4 = new Retrieval(1, 1598745600000, 1598659200000, Status.RetrievalStatus.retrieved, "P011 only 9 items left, spoilt", true);
            dbcontext.Add(retr4);
            dbcontext.SaveChanges();



            //seed requsition
            //public Requisition(string DepartmentId, int ReqByEmpId, int ApprovedById, int ProcessedByClerkId)
            Requisition r1 = new Requisition("ENGL", 4, 5, 1);
            r1.CreatedDate = 1594735200000;//14/7/2020 @ 2:00pm (UTC)
            r1.Status = Status.RequsitionStatus.rejected;
            r1.Remarks = "Rejected as per request by staff.";
            dbcontext.Add(r1);
            Requisition r2 = new Requisition("ENGL", 6, 5, 1);
            r2.CreatedDate = 1597060800000;//10/8/2020 @ 12:00pm (UTC)
            r2.Status = Status.RequsitionStatus.pendapprov;
            r2.CollectionPointId = 5;
            dbcontext.Add(r2);
            dbcontext.SaveChanges();


            //public Requisition(string DepartmentId, int ReqByEmpId, int ApprovedById, string? Remarks,int ProcessedByClerkId, long CreatedDate, string Status,
            //int? CollectionPointId, long? CollectionDate, int? ReceivedByRepId, long? ReceivedDate, int? AckByClerkId, long? AckDate)

            //requisition on 14/7/2020 @ 2:00pm (UTC),dilivered &received on 20/7 @9:30am, 
            Requisition r3 = new Requisition("CPSC", 15, 7, null, 1, 1597060800000, Status.RequsitionStatus.completed,   
                                               1, 1597881600000,
                                               4, 1595237400000, 1, 1595237400000);

            Requisition r4 = new Requisition("ENGL", 4, 5, null, 1, 1597060800000, Status.RequsitionStatus.completed,
                                               1, 1597881600000,
                                               4, 1595237400000, 1, 1595237400000);

            //create date- Wednesday, 29-Jul-20 00:00:00 UTC ;receive-20/8/2020 @ 0:00am (UTC);acknowldge-03/8/2020 @ 9:30am
            Requisition r5 = new Requisition("ENGL", 14, 5, null, 1, 1595980800000, Status.RequsitionStatus.completed,
                                               1, 1597881600000,
                                               4, 1596447000000, 1, 1596447000000);

            //created-05 /8/ 2020 00:00:00 (UTC); collection-date-10/8/2020 @0:00 UTC; received and confirmed-10/8/2020  @0:00 UTC
            Requisition r6 = new Requisition("ENGL", 4, 5, null, 16, 1596585600000, Status.RequsitionStatus.completed,
                                               1, 1597017600000,
                                               4, 1597017600000, 1, 1597017600000);
            //created-05 /8/ 2020 00:00:00 (UTC); collection-date-10/8/2020 @0:00 UTC; received and confirmed-10/8/2020 @0:00 UTC
            Requisition r7 = new Requisition("CPSC", 15, 7, null, 16, 1596585600000, Status.RequsitionStatus.completed,
                                               1, 1597017600000,
                                               4, 1597017600000, 1, 1597017600000);


            dbcontext.Add(r3);
            dbcontext.SaveChanges();
            dbcontext.Add(r4);
            dbcontext.SaveChanges();
            dbcontext.Add(r5);
            dbcontext.SaveChanges();
            dbcontext.Add(r6);
            dbcontext.SaveChanges();
            dbcontext.Add(r7);
            dbcontext.SaveChanges();

            //created-30/8/2020 00:00:00 (GMT); collection-date-25/8/2020 @00:00am(GMT)
            Requisition r8 = new Requisition("ENGL", 4, 5, 1);
            r8.CreatedDate = 1598745600000;
            r8.Status = Status.RequsitionStatus.confirmed;
            r8.CollectionPointId = 1;
            r8.CollectionDate = 1599004800000;
            dbcontext.Add(r8);
            dbcontext.SaveChanges();

            //created-05/8/2020 00:00:00 (UTC); collection-date-20/8/2020 @00:00am(GMT)
            Requisition r9 = new Requisition("ENGL", 14, 5, 1);
            r9.CreatedDate = 1598486400000;
            r9.Status = Status.RequsitionStatus.confirmed;
            r9.CollectionPointId = 1;
            r9.CollectionDate = 1599004800000;
            dbcontext.Add(r9);
            dbcontext.SaveChanges();

            //created-30/8/2020 00:00:00 (GMT)
            Requisition r10 = new Requisition("ENGL", 14, 5, 1);
            r10.CreatedDate = 1598745600000;
            r10.Status = Status.RequsitionStatus.approved;
            r10.CollectionPointId = 5;
            dbcontext.Add(r10);
            dbcontext.SaveChanges();

            //created-25/8/2020 00:00:00 (UTC); collection-date-30/8/2020 @00:00am(localtime)
            Requisition r11 = new Requisition("ENGL", 14, 7, 1);
            r11.CreatedDate = 1598313600000;
            r11.Status = Status.RequsitionStatus.confirmed;
            r11.CollectionPointId = 1;
            r11.CollectionDate = 1598745600000;
            dbcontext.Add(r11);
            dbcontext.SaveChanges();

            Requisition r12 = new Requisition("ENGL", 14, 5, 1);
            r12.CreatedDate = 1598054400000;// 22/8/2020 @ 00:00am (UTC)
            r12.Status = Status.RequsitionStatus.created;
            r12.CollectionPointId = 5;
            dbcontext.Add(r12);
            dbcontext.SaveChanges();

            Requisition r13 = new Requisition("ENGL", 4, 5, 1);
            r13.CreatedDate = 1598054400000;// 22/8/2020 @ 00:00am (UTC)
            r13.Status = Status.RequsitionStatus.pendapprov;
            r13.CollectionPointId = 5;
            dbcontext.Add(r13);
            dbcontext.SaveChanges();

            Requisition r14 = new Requisition("ENGL", 14, 5, 1);
            r14.CreatedDate = 1598054400000;// 22/8/2020 @ 00:00am (UTC)
            r14.Status = Status.RequsitionStatus.pendapprov;
            r14.CollectionPointId = 5;
            dbcontext.Add(r14);
            dbcontext.SaveChanges();



            //seed requsition detail
            //public RequisitionDetail(int RequisitionId, string ProductId, int QtyNeeded, int? QtyDisbursed, int? QtyReceived,
            //string? DisburseRemark, string? RepRemark, string? ClerkRemark, int? RetrievalId)
            RequisitionDetail rd1 = new RequisitionDetail(1, "C001", 500);
            dbcontext.Add(rd1);
            dbcontext.SaveChanges();
            RequisitionDetail rd2 = new RequisitionDetail(2, "C001", 15);
            dbcontext.Add(rd2);
            dbcontext.SaveChanges();
            RequisitionDetail rd25 = new RequisitionDetail(4, "C001", 15);
            dbcontext.Add(rd25);
            dbcontext.SaveChanges();
            RequisitionDetail rd3 = new RequisitionDetail(5, "C001", 10, 10, 10, null, null, null, 1);//refer to retr1
            dbcontext.Add(rd3);
            dbcontext.SaveChanges();
            RequisitionDetail rd4 = new RequisitionDetail(5, "C001", 50, 50, 50, null, null, null, 1);//retr1
            dbcontext.Add(rd4);
            dbcontext.SaveChanges();
            RequisitionDetail rd5 = new RequisitionDetail(5, "P043", 20, 20, 20, null, null, null, 2);//retr2
            dbcontext.Add(rd5);
            dbcontext.SaveChanges();
            RequisitionDetail rd6 = new RequisitionDetail(6, "P043", 50, 50, 50, null, null, null, 3);//retr3
            dbcontext.Add(rd6);
            dbcontext.SaveChanges();
            RequisitionDetail rd7 = new RequisitionDetail(6, "C001", 10, 8, 8, "only 8 left", "noted", null, 3);//retr3
            dbcontext.Add(rd7);
            dbcontext.SaveChanges();
            RequisitionDetail rd8 = new RequisitionDetail(7, "P043", 30, 30, 28, null, "2 spoilt during delivery", "confirmed", 3); //sub need to raise 2 in voucher
            dbcontext.Add(rd8);
            dbcontext.SaveChanges();
            RequisitionDetail rd9 = new RequisitionDetail(7, "C001", 10, 10, 10, null, null, null, 3);
            dbcontext.Add(rd9);
            dbcontext.SaveChanges();

            RequisitionDetail rd10 = new RequisitionDetail(8, "C001", 10);
            dbcontext.Add(rd10);
            dbcontext.SaveChanges();
            RequisitionDetail rd11 = new RequisitionDetail(8, "F021", 10);
            dbcontext.Add(rd11);
            dbcontext.SaveChanges();
            RequisitionDetail rd12 = new RequisitionDetail(8, "P010", 10);
            dbcontext.Add(rd12);
            dbcontext.SaveChanges();

            RequisitionDetail rd13 = new RequisitionDetail(9, "C001", 5);
            dbcontext.Add(rd13);
            dbcontext.SaveChanges();
            RequisitionDetail rd14 = new RequisitionDetail(9, "F021", 5);
            dbcontext.Add(rd14);
            dbcontext.SaveChanges();
            RequisitionDetail rd15 = new RequisitionDetail(9, "P010", 5);
            dbcontext.Add(rd15);
            dbcontext.SaveChanges();

            RequisitionDetail rd16 = new RequisitionDetail(10, "C004", 5);
            dbcontext.Add(rd16);
            dbcontext.SaveChanges();
            RequisitionDetail rd17 = new RequisitionDetail(10, "F020", 5);
            dbcontext.Add(rd17);
            dbcontext.SaveChanges();
            RequisitionDetail rd18 = new RequisitionDetail(10, "P011", 10);
            dbcontext.Add(rd18);
            dbcontext.SaveChanges();

            RequisitionDetail rd19 = new RequisitionDetail(11, "F021", 5, 5, null, null, null, null, 4);
            dbcontext.Add(rd19);
            dbcontext.SaveChanges();
            RequisitionDetail rd20 = new RequisitionDetail(11, "P011", 10, 9, null, "Only 9 items left", null, null, 4);
            dbcontext.Add(rd20);
            dbcontext.SaveChanges();

            RequisitionDetail rd21 = new RequisitionDetail(12, "C001", 10);
            dbcontext.Add(rd21);
            dbcontext.SaveChanges();
            RequisitionDetail rd22 = new RequisitionDetail(12, "E032", 10);
            dbcontext.Add(rd22);
            dbcontext.SaveChanges();

            RequisitionDetail rd23 = new RequisitionDetail(13, "C001", 5);
            dbcontext.Add(rd23);
            dbcontext.SaveChanges();
            RequisitionDetail rd24 = new RequisitionDetail(13, "E032", 6);
            dbcontext.Add(rd24);
            dbcontext.SaveChanges();

            RequisitionDetail rd26 = new RequisitionDetail(14, "C001", 20);
            dbcontext.Add(rd26);
            dbcontext.SaveChanges();
            RequisitionDetail rd27 = new RequisitionDetail(14, "E032", 20);
            dbcontext.Add(rd27);
            dbcontext.SaveChanges();

            RequisitionDetail rd28 = new RequisitionDetail(3, "F021",10);
            dbcontext.Add(rd28);
            dbcontext.SaveChanges();
            RequisitionDetail rd29 = new RequisitionDetail(3, "D001", 5);
            dbcontext.Add(rd29);
            dbcontext.SaveChanges();


            //seed adjustment voucher
            //public AdjustmentVoucher(string Id, int InitiatedClerkId, long InitiatedDate, 
            //int? ApprovedSupId, long? ApprovedSupDate, int? ApprovedMgrId, long? ApprovedMgrDate, string Status)

            //adjustment voucher in June that >250,due to wet exercise book"E032"x100 and spoilt diskettes "D001"x20 ,
            //created on 29/6@9:00am; approved by sup on 29/6@ 3:00pm, and approved by manager on 30/6/@3:00pm
            AdjustmentVoucher adj1 = new AdjustmentVoucher("029_06_2020", 16, 1593421200000, 2, 1593442800000, 3, 1593529200000, Status.AdjVoucherStatus.approved);
            dbcontext.Add(adj1);
            dbcontext.SaveChanges();

            //Adjustment voucher raised on 31/7; due to 2 rusty clips found on 17/7/2020 retrival, approved by sup on 3/8/2020
            AdjustmentVoucher adj2 = new AdjustmentVoucher("031_07_2020", 1, 1596207600000, 2, 1596447000000, Status.AdjVoucherStatus.pendapprov);
            dbcontext.Add(adj2);
            dbcontext.SaveChanges();

            //Adjustment voucher raised on 15/8 approved by sup on 16/8/2020
            AdjustmentVoucher adj3 = new AdjustmentVoucher("001_08_2020", 1, 1597449600000, 2, 1597536000000, Status.AdjVoucherStatus.created);
            dbcontext.Add(adj3);
            dbcontext.SaveChanges();

            //seed adjustment voucher detail
            //adjustment voucher in June that >250,due to wet paper"E032" x100 and spoilt diskettes "D001"x20, created on 29/6@9:00am; and approved by manager on 30/6/3pm
            //wet paper"E032" x100
            AdjustmentVoucherDetail adjdet1 = new AdjustmentVoucherDetail("029_06_2020", "E032", 100,1.00, 100.0, "100 wet paper due to heavy rain");
            dbcontext.Add(adjdet1);
            dbcontext.SaveChanges();

            AdjustmentVoucherDetail adjdet2 = new AdjustmentVoucherDetail("031_07_2020", "D001", 20,10.00, 200.00, "20 diskettes found spoilt due to heavy rain");
            dbcontext.Add(adjdet2);
            dbcontext.SaveChanges();

            //public AdjustmentVoucherDetail(string AdjustmentVoucherId, string ProductId, int QtyAdjusted, double TotalPrice, string Reason)
            //seed purchase request detail
            AdjustmentVoucherDetail adjdet3 = new AdjustmentVoucherDetail("031_07_2020", "C001", 2, 2.00,4.00, "2 clips in inventory found rusty, spoilt");
            dbcontext.Add(adjdet3);
            dbcontext.SaveChanges();


            AdjustmentVoucherDetail adjdet4 = new AdjustmentVoucherDetail("001_08_2020", "D001", 26, 10, 260.00, "26 diskettes went missing");
            dbcontext.Add(adjdet4);
            dbcontext.SaveChanges();

            AdjustmentVoucherDetail adjdet5 = new AdjustmentVoucherDetail("001_08_2020", "E032", 2, 1.00, 2.00, "Exercise book - water damage");
            dbcontext.Add(adjdet5);
            dbcontext.SaveChanges();


            //seed Purchase Request Details
            //public PurchaseRequestDetail(int PurchaseRequestId, int CreatedByClerkId, string ProductId, string SupplierId, int CurrentStock,
            //int ReorderQty, string? VenderQuote, double TotalPrice, long? SubmitDate, long? ApprovedDate, int? ApprovedBySupId,
            //string Status, string? Remarks)

            //1/7/2020@3:30pm Purchase request of paper"E032" x100 and spoilt diskettes "D001"x20, and "C001"x15,
            //approved on 2/7/2020@12pm, supply by 15/7,received on 14 / 7 / 2020 @ 11:00am(UTC)
            PurchaseRequestDetail PRDet1 = new PurchaseRequestDetail(37943271428, 1, "E032", "ALPA", 80, 100, "MF032", 100.00, 1593617400000, 1593691200000, 2, Status.PurchaseRequestStatus.approved, null);
            PurchaseRequestDetail PRDet2 = new PurchaseRequestDetail(37943271428, 1, "D001", "OMEG", 10, 30, "MFD001", 300.00, 1593617400000, 1593691200000, 2, Status.PurchaseRequestStatus.approved, null);
            PurchaseRequestDetail PRDet3 = new PurchaseRequestDetail(37971428571, 1, "C001", "ALPA", 50, 15, "MFC001", 30.00, 1594800000000, 1593691200000, 2, Status.PurchaseRequestStatus.approved, null);

            // 15/7 / 2020 @ 8:00am Purchase request of Clip "C001"x15, supply by 31/7/2020 @00:00, Approved on 17/7@10:00 recieved on 29/7/2020 @ 9:30am(trans13)
            PurchaseRequestDetail PRDet4 = new PurchaseRequestDetail(37943271428, 1, "C001", "ALPA", 3, 15, "MFC001", 30.00, 1593617400000, 1596153600000, 2, Status.PurchaseRequestStatus.approved, null);

            // 29/7@9:30am  Purchase order of "P043"x500 Requested, supply by 12/8/2020,approved on 30/7, received on 3/8/2020@8:30am (trans1)
            PurchaseRequestDetail PRDet5 = new PurchaseRequestDetail(37998257142, 16, "P043", "BANE", 50, 500, "MF043", 500.00, 1595926800000, 1596441600000, 2, Status.PurchaseRequestStatus.approved, null);
            dbcontext.Add(PRDet1);
            dbcontext.SaveChanges();
            dbcontext.Add(PRDet2);
            dbcontext.SaveChanges();
            dbcontext.Add(PRDet3);
            dbcontext.SaveChanges();
            dbcontext.Add(PRDet4);
            dbcontext.SaveChanges();
            dbcontext.Add(PRDet5);
            dbcontext.SaveChanges();

            //seed purchase order per supplier
            //  public PurchaseOrder(string SupplierId, double TotalPrice, int OrderedByClerkId, long? OrderedDate, long SupplyByDate, int? ApprovedBySupId,
            // int? ReceivedByClerkId, long? ReceivedDate,string Status)
            //1/7/2020@3:30pm Purchase request of paper"E032" x100 and spoilt diskettes "D001"x20, and "C001"x15 supply by 15/7,received on 14 / 7 / 2020 @ 11:00am(UTC)
            PurchaseOrder po1 = new PurchaseOrder("ALPA", 130.00, 1, 1593617400000, 1594771200000, 2);
            PurchaseOrder po2 = new PurchaseOrder("OMEG", 300.00, 1, 1593617400000, 1594771200000, 2);

            // 15/7 / 2020 @ 8:00am Purchase request of Clip "C001"x15, supply by 31/7/2020 @00:00, recieved on 29/7/2020 @ 9:30am(trans13)
            PurchaseOrder po3 = new PurchaseOrder("ALPA", 30.00, 1, 1594800000000, 1596153600000, 2);

            PurchaseOrder po4 = new PurchaseOrder("BANE", 100.00, 16, 1595926800000, 1597190400000, 2);
            dbcontext.Add(po1);
            dbcontext.SaveChanges();
            dbcontext.Add(po2);
            dbcontext.SaveChanges();
            dbcontext.Add(po3);
            dbcontext.SaveChanges();
            dbcontext.Add(po4); 
            dbcontext.SaveChanges();



            //seed purchase order detail

            //public PurchaseOrderDetail(int? PurchaseOrderId, int? PurchaseRequestDetailId, string ProductId, int QtyPurchased, int? QtyReceived,
            //double TotalPrice, int? SupplierDeliveryNo, string? Remark, string Status)

            //PurchaseOrderDetail poDet1 = new PurchaseOrderDetail(1, 1, "E032", 100, null, 100.00, null, "Only 80 left in 1st supplier", Status.PurchaseOrderStatus.approved);
            //PurchaseOrderDetail poDet2 = new PurchaseOrderDetail(1, 3, "C001", 15, null, 30.00, null, null, Status.PurchaseOrderStatus.approved);
            //PurchaseOrderDetail poDet3 = new PurchaseOrderDetail(2, 2, "D001", 30, null, 300.00, null, null, Status.PurchaseOrderStatus.approved);
            //PurchaseOrderDetail poDet4 = new PurchaseOrderDetail(3, 4, "C001", 15, null, 30.00, null, null, Status.PurchaseOrderStatus.approved);
            //PurchaseOrderDetail poDet5 = new PurchaseOrderDetail(4, 5, "P043", 500, null, 500.00, null, null, Status.PurchaseOrderStatus.approved);
            PurchaseOrderDetail poDet1 = new PurchaseOrderDetail(1, 1, "E032", 100, null, 100.00, null, "Only 80 left in 1st supplier", Status.PurchaseOrderDetailStatus.pending);
            PurchaseOrderDetail poDet2 = new PurchaseOrderDetail(1, 3, "C001", 15, null, 30.00, null, null, Status.PurchaseOrderDetailStatus.pending);
            PurchaseOrderDetail poDet3 = new PurchaseOrderDetail(2, 2, "D001", 30, null, 300.00, null, null, Status.PurchaseOrderDetailStatus.pending);
            PurchaseOrderDetail poDet4 = new PurchaseOrderDetail(3, 4, "C001", 15, null, 30.00, null, null, Status.PurchaseOrderDetailStatus.pending);
            PurchaseOrderDetail poDet5 = new PurchaseOrderDetail(4, 5, "P043", 500, null, 500.00, null, null, Status.PurchaseOrderDetailStatus.pending);
            dbcontext.Add(poDet1);
            dbcontext.Add(poDet2);
            dbcontext.Add(poDet3);
            dbcontext.Add(poDet4);
            dbcontext.Add(poDet5);
            dbcontext.SaveChanges();




        }
    }
}
