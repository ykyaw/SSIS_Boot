﻿using System;
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
            dbcontext.Add(ca1); 
            dbcontext.SaveChanges();
            Category ca2 = new Category("Envelope", "E1");
            dbcontext.Add(ca2);
            dbcontext.SaveChanges();
            Category ca3 = new Category("Eraser", "E2");
            dbcontext.Add(ca3);
            dbcontext.SaveChanges();
            Category ca4 = new Category("Exercises", "E3");
            dbcontext.Add(ca4);
            dbcontext.SaveChanges();
            Category ca5 = new Category("File", "F1");
            dbcontext.Add(ca5);
            dbcontext.SaveChanges();
            Category ca6 = new Category("Pen", "H1");
            dbcontext.Add(ca6);
            dbcontext.SaveChanges();
            Category ca7 = new Category("Puncher", "H2");
            dbcontext.Add(ca7);
            dbcontext.SaveChanges();
            Category ca8 = new Category("Pad", "P1");
            dbcontext.Add(ca8);
            dbcontext.SaveChanges();
            Category ca9 = new Category("Paper", "P2");
            dbcontext.Add(ca9);
            dbcontext.SaveChanges();
            Category ca10 = new Category("Ruler", "R1");
            dbcontext.Add(ca10);
            dbcontext.SaveChanges();
            Category ca11 = new Category("Scissors", "S1");
            dbcontext.Add(ca11);
            dbcontext.SaveChanges();
            Category ca12 = new Category("Tape", "S2");
            dbcontext.Add(ca12);
            dbcontext.SaveChanges();
            Category ca13 = new Category("Sharpener", "S3");
            dbcontext.Add(ca13);
            dbcontext.SaveChanges();
            Category ca14 = new Category("Shorthand", "S4");
            dbcontext.Add(ca14);
            dbcontext.SaveChanges();
            Category ca15 = new Category("Stapler", "S5");
            dbcontext.Add(ca15);
            dbcontext.SaveChanges();
            Category ca16 = new Category("Tacks", "T1");
            dbcontext.Add(ca16);
            dbcontext.SaveChanges();
            Category ca17 = new Category("Tparency", "T2");
            dbcontext.Add(ca17);
            dbcontext.SaveChanges();
            Category ca18 = new Category("Tray", "T3");
            dbcontext.Add(ca18);
            dbcontext.SaveChanges();
            Category ca19 = new Category("Hardware", "D1");
            dbcontext.Add(ca19);
            dbcontext.SaveChanges();


            //seed product
            //public Product(string Id, string Description, int CategoryId, int ReorderLvl, int ReorderQty, string Uom)
            Product p1 = new Product("C001", "Clips Double 1", 1, 15, 15, "Dozen");
            Product p2 = new Product("C002", "Clips Double 2", 1, 30, 50, "Dozen");
            Product p3 = new Product("C003", "Clips Double 3/4", 1, 15, 15, "Dozen");
            Product p4 = new Product("C004", "Clips Paper Large", 1, 15, 15, "Box");
            Product p5 = new Product("E001", "Envelope Brown (3'x6')", 2, 100, 100, "Each");
            Product p6 = new Product("E002", "Envelope Brown (3'x6') w/Window", 2, 100, 100, "Each");
            Product p7 = new Product("E003", "Envelope Brown (6'x7')", 2, 100, 100, "Each");
            Product p8 = new Product("E004", "Envelope Brown (6'x7') w/Window", 2, 100, 100, "Each");
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
            CollectionPoint c1 = new CollectionPoint("Stationery Store", "9:30AM");
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
            Department d1 = new Department("STOR", "LU Stationery Store", 9999999);
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
            Employee e7 = new Employee("Soh Kian Wee(dh)", "Kianweelu@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "CPSC", "dh");
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

            //Product p5 = new Product("E001", "Envelope Brown (3'x6')", 2, 100, 100, "Each");
            TenderQuotation q5a = new TenderQuotation("OMEG", 2020, "E001", 10, "Each", 1);
            TenderQuotation q5b = new TenderQuotation("ALPA", 2020, "E001", 10.50, "Each", 2);
            TenderQuotation q5c = new TenderQuotation("BANE", 2020, "E001", 11.00, "Each", 3);
            TenderQuotation q5d = new TenderQuotation("CHEP", 2020, "E001", 11.00, "Each", null);
            dbcontext.Add(q5a);
            dbcontext.Add(q5b);
            dbcontext.Add(q5c);
            dbcontext.Add(q5d);

            //Product p6 = new Product("E002", "Envelope Brown (3'x6') w/Window", 2, 100, 100, "Each");
            TenderQuotation q6a = new TenderQuotation("OMEG", 2020, "E002", 10, "Each", 1);
            TenderQuotation q6b = new TenderQuotation("ALPA", 2020, "E002", 10.50, "Each", 2);
            TenderQuotation q6c = new TenderQuotation("BANE", 2020, "E002", 11.00, "Each", 3);
            TenderQuotation q6d = new TenderQuotation("CHEP", 2020, "E002", 11.00, "Each", null);
            dbcontext.Add(q6a);
            dbcontext.Add(q6b);
            dbcontext.Add(q6c);
            dbcontext.Add(q6d);

            //Product p7 = new Product("E003", "Envelope Brown (6'x7')", 2, 100, 100, "Each");
            TenderQuotation q7a = new TenderQuotation("OMEG", 2020, "E003", 10, "Each", 1);
            TenderQuotation q7b = new TenderQuotation("ALPA", 2020, "E003", 10.50, "Each", 2);
            TenderQuotation q7c = new TenderQuotation("BANE", 2020, "E003", 11.00, "Each", 3);
            TenderQuotation q7d = new TenderQuotation("CHEP", 2020, "E003", 11.00, "Each", null);
            dbcontext.Add(q7a);
            dbcontext.Add(q7b);
            dbcontext.Add(q7c);
            dbcontext.Add(q7d);

            //Product p8 = new Product("E004", "Envelope Brown (6'x7') w/Window", 2, 100, 100, "Each");
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
            TenderQuotation q31c = new TenderQuotation("BANE", 2020, "D001", 12, "Box", 1);
            TenderQuotation q31b = new TenderQuotation("ALPA", 2020, "D001", 11, "Box", 2);
            TenderQuotation q31a = new TenderQuotation("OMEG", 2020, "D001", 10, "Box", 3);
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
            
            //Retrieval retr1 = new Retrieval(1, 1595237400000, 1594994400000, Status.RetrievalStatus.retrieved);
            //dbcontext.Add(retr1);
            //dbcontext.SaveChanges();
            //Fri 31/7/2020 @3:00 to retrive, disbursement on 3/8,item "P043" to ENGL (cover 1 rows in ReqDet)

            Retrieval retr1 = new Retrieval(1, 1596585600000, 1596412800000, Status.RetrievalStatus.retrieved);
            dbcontext.Add(retr1);
            dbcontext.SaveChanges();
            //Fri 7//8/2020 @3:00 to retrive, disbursement on 10/8,item "P043" and "C001" to ENGL and CPSC(cover 4 rows in ReqDet)
            Retrieval retr2 = new Retrieval(1, 1597881600000, 1597708800000, Status.RetrievalStatus.retrieved, "2 clips in inventory found rusty, spoilt", true);
            dbcontext.Add(retr2);
            dbcontext.SaveChanges();

            Retrieval retr3 = new Retrieval(1, 1599091200000, 1598918400000, Status.RetrievalStatus.retrieved, "P011 only 9 items left, spoilt", true);
            dbcontext.Add(retr3);
            dbcontext.SaveChanges();



            //seed requsition
            //public Requisition(string DepartmentId, int ReqByEmpId, int ApprovedById, int ProcessedByClerkId)
            Requisition r1 = new Requisition("ENGL", 4, 5, 1);
            r1.CreatedDate = 1597104000000;//11/8/2020 @ 0:00am (UTC)
            r1.Status = Status.RequsitionStatus.rejected;
            r1.CollectionPointId = 5;
            r1.Remarks = "Rejected as per request by staff";
            dbcontext.Add(r1);
            Requisition r2 = new Requisition("ENGL", 6, 5, 1);
            r2.CreatedDate = 1597060800000;//10/8/2020 @ 12:00pm (UTC)
            r2.Status = Status.RequsitionStatus.pendapprov;
            r2.CollectionPointId = 5;
            dbcontext.Add(r2);
            dbcontext.SaveChanges();


            //public Requisition(string DepartmentId, int ReqByEmpId, int ApprovedById, string? Remarks,int? ProcessedByClerkId, long CreatedDate, string Status,
            //int? CollectionPointId, long? CollectionDate, int? ReceivedByRepId, long? ReceivedDate, int? AckByClerkId, long? AckDate)

            //requisition on 14/7/2020 @ 2:00pm (UTC),dilivered &received on 20/7 @9:30am, 
            Requisition r3 = new Requisition("CPSC", 15, 7, null, 1, 1597060800000, Status.RequsitionStatus.completed,   
                                               1, 1597881600000,
                                               4, 1595237400000, 1, 1595237400000);

            Requisition r4 = new Requisition("ENGL", 4, 5, null, 1, 1597060800000, Status.RequsitionStatus.completed,
                                               1, 1597881600000,
                                               4, 1595237400000, 1, 1595237400000);

            ////create date- Wednesday, 29-Jul-20 00:00:00 UTC ;receive-20/8/2020 @ 0:00am (UTC);acknowldge-03/8/2020 @ 9:30am
            //Requisition r5 = new Requisition("ENGL", 14, 5, null, 1, 1595980800000, Status.RequsitionStatus.completed,
            //                                   1, 1597881600000,
            //                                   4, 1596447000000, 1, 1596447000000);

            ////created-05 /8/ 2020 00:00:00 (UTC); collection-date-10/8/2020 @0:00 UTC; received and confirmed-10/8/2020  @0:00 UTC
            //Requisition r6 = new Requisition("ENGL", 4, 5, null, 16, 1596585600000, Status.RequsitionStatus.completed,
            //                                   1, 1597017600000,
            //                                   4, 1597017600000, 1, 1597017600000);
            ////created-05 /8/ 2020 00:00:00 (UTC); collection-date-10/8/2020 @0:00 UTC; received and confirmed-10/8/2020 @0:00 UTC
            //Requisition r7 = new Requisition("CPSC", 15, 7, null, 16, 1596585600000, Status.RequsitionStatus.completed,
            //                                   1, 1597017600000,
            //                                   4, 1597017600000, 1, 1597017600000);


            dbcontext.Add(r3);
            dbcontext.SaveChanges();
            dbcontext.Add(r4);
            dbcontext.SaveChanges();
            //dbcontext.Add(r5);
            //dbcontext.SaveChanges();
            //dbcontext.Add(r6);
            //dbcontext.SaveChanges();
            //dbcontext.Add(r7);
            //dbcontext.SaveChanges();

            //created-22/8/2020 00:00:00 (GMT); collection-date-25/8/2020 @00:00am(GMT)
            Requisition r5 = new Requisition("ENGL", 4, 5, 1);
            r5.CreatedDate = 1598054400000;
            r5.Status = Status.RequsitionStatus.confirmed;
            r5.CollectionPointId = 1;
            r5.CollectionDate = 1599004800000;
            dbcontext.Add(r5);
            dbcontext.SaveChanges();

            //created-05/8/2020 00:00:00 (UTC); collection-date-20/8/2020 @00:00am(GMT)
            Requisition r6 = new Requisition("ENGL", 14, 5, 1);
            r6.CreatedDate = 1598486400000;
            r6.Status = Status.RequsitionStatus.confirmed;
            r6.CollectionPointId = 1;
            r6.CollectionDate = 1599004800000;
            dbcontext.Add(r6);
            dbcontext.SaveChanges();

            //created-30/8/2020 00:00:00 (GMT)
            Requisition r7 = new Requisition("ENGL", 14, 5, 1);
            r7.CreatedDate = 1598486400000;
            r7.Status = Status.RequsitionStatus.approved;
            r7.CollectionPointId = 5;
            dbcontext.Add(r7);
            dbcontext.SaveChanges();

            //created-25/8/2020 00:00:00 (UTC); collection-date-30/8/2020 @00:00am(localtime)
            Requisition r8 = new Requisition("ENGL", 14, 7, 1);
            r8.CreatedDate = 1598486400000;
            r8.Status = Status.RequsitionStatus.confirmed;
            r8.CollectionPointId = 1;
            r8.CollectionDate = 1599091200000;
            dbcontext.Add(r8);
            dbcontext.SaveChanges();

            Requisition r9 = new Requisition("ENGL", 14, 5, 1);
            r9.CreatedDate = 1598659200000;// 22/8/2020 @ 00:00am (UTC)
            r9.Status = Status.RequsitionStatus.created;
            r9.CollectionPointId = 5;
            dbcontext.Add(r9);
            dbcontext.SaveChanges();

            Requisition r10 = new Requisition("ENGL", 4, 5, 1);
            r10.CreatedDate = 1598745600000;// 30/8/2020 @ 00:00am (UTC)
            r10.Status = Status.RequsitionStatus.pendapprov;
            r10.CollectionPointId = 5;
            dbcontext.Add(r10);
            dbcontext.SaveChanges();

            Requisition r11 = new Requisition("ENGL", 14, 5, 1);
            r11.CreatedDate = 1598745600000;// 30/8/2020 @ 00:00am (UTC)
            r11.Status = Status.RequsitionStatus.pendapprov;
            r11.CollectionPointId = 5;
            dbcontext.Add(r11);
            dbcontext.SaveChanges();

            //create date- Wednesday, 29-Jul-20 00:00:00 UTC ;receive-05/8/2020 @ 0:00am (UTC);acknowldge-05/8/2020 @ 0:00am
            Requisition r12 = new Requisition("CPSC", 15, 7, null, 16, 1595980800000, Status.RequsitionStatus.completed,
                                               1, 1596585600000,
                                               4, 1596412800000, 1, 1596585600000);
            dbcontext.Add(r12);


            Requisition r13 = new Requisition("ENGL", 6, 5, 1);
            r13.CreatedDate = 1598486400000;// 27/8/2020 @ 00:00am (UTC)
            r13.Status = Status.RequsitionStatus.pendapprov;
            r13.CollectionPointId = 5;
            dbcontext.Add(r13);
           
            //create date- Wednesday, 25-Aug-20 00:00:00 UTC ;receive-29/8/2020 @ 0:00am (UTC);acknowldge-29/8/2020 @ 0:00am
            Requisition r14 = new Requisition("COMM", 8, 9, 1);
            r14.CreatedDate = 1598313600000;
            r14.Status = Status.RequsitionStatus.confirmed;
            r14.CollectionDate = 1599091200000;
            r4.CollectionPointId = 1;

            dbcontext.Add(r14);
            dbcontext.SaveChanges();

            //Requisition from CSV Seeder
            Requisition r15 = new Requisition("CPSC", 15, 7, null, null, 1325380000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r16 = new Requisition("ENGL", 4, 5, null, null, 1328050000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r17 = new Requisition("ENGL", 4, 5, null, null, 1330560000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r18 = new Requisition("ENGL", 14, 5, null, null, 1333240000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r19 = new Requisition("CPSC", 6, 7, null, null, 1335830000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r20 = new Requisition("ENGL", 4, 5, null, null, 1338510000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r21 = new Requisition("CPSC", 6, 7, null, null, 1341100000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r22 = new Requisition("CPSC", 15, 7, null, null, 1343780000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r23 = new Requisition("ENGL", 4, 5, null, null, 1346460000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r24 = new Requisition("ENGL", 4, 5, null, null, 1349050000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r25 = new Requisition("ENGL", 14, 5, null, null, 1351730000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r26 = new Requisition("CPSC", 6, 7, null, null, 1354320000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r27 = new Requisition("CPSC", 6, 7, null, null, 1357000000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r28 = new Requisition("ENGL", 4, 5, null, null, 1359680000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r29 = new Requisition("CPSC", 6, 7, null, null, 1362100000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r30 = new Requisition("ENGL", 14, 5, null, null, 1364770000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r31 = new Requisition("ENGL", 4, 5, null, null, 1367370000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r32 = new Requisition("ENGL", 4, 5, null, null, 1370040000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r33 = new Requisition("ENGL", 14, 5, null, null, 1372640000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r34 = new Requisition("CPSC", 6, 7, null, null, 1375320000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r35 = new Requisition("ENGL", 4, 5, null, null, 1377990000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r36 = new Requisition("CPSC", 6, 7, null, null, 1380590000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r37 = new Requisition("CPSC", 15, 7, null, null, 1383260000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r38 = new Requisition("ENGL", 4, 5, null, null, 1385860000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r39 = new Requisition("ENGL", 4, 5, null, null, 1388530000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r40 = new Requisition("ENGL", 14, 5, null, null, 1391210000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r41 = new Requisition("CPSC", 6, 7, null, null, 1393630000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r42 = new Requisition("ENGL", 14, 5, null, null, 1396310000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r43 = new Requisition("CPSC", 6, 7, null, null, 1398900000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r44 = new Requisition("CPSC", 15, 7, null, null, 1401580000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r45 = new Requisition("ENGL", 4, 5, null, null, 1404170000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r46 = new Requisition("ENGL", 4, 5, null, null, 1406850000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r47 = new Requisition("ENGL", 14, 5, null, null, 1409530000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r48 = new Requisition("CPSC", 6, 7, null, null, 1412120000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r49 = new Requisition("ENGL", 4, 5, null, null, 1414800000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r50 = new Requisition("CPSC", 6, 7, null, null, 1417390000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r51 = new Requisition("CPSC", 15, 7, null, null, 1420070000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r52 = new Requisition("ENGL", 4, 5, null, null, 1422750000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r53 = new Requisition("ENGL", 4, 5, null, null, 1425170000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r54 = new Requisition("ENGL", 14, 5, null, null, 1427850000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r55 = new Requisition("CPSC", 6, 7, null, null, 1430440000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r56 = new Requisition("ENGL", 4, 5, null, null, 1433120000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r57 = new Requisition("CPSC", 6, 7, null, null, 1435710000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r58 = new Requisition("CPSC", 15, 7, null, null, 1438390000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r59 = new Requisition("ENGL", 4, 5, null, null, 1441070000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r60 = new Requisition("ENGL", 4, 5, null, null, 1443660000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r61 = new Requisition("ENGL", 14, 5, null, null, 1446340000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r62 = new Requisition("CPSC", 6, 7, null, null, 1448930000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r63 = new Requisition("CPSC", 6, 7, null, null, 1451610000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r64 = new Requisition("ENGL", 4, 5, null, null, 1454280000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r65 = new Requisition("CPSC", 6, 7, null, null, 1456790000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r66 = new Requisition("ENGL", 14, 5, null, null, 1459470000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r67 = new Requisition("ENGL", 4, 5, null, null, 1462060000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r68 = new Requisition("ENGL", 4, 5, null, null, 1464740000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r69 = new Requisition("ENGL", 14, 5, null, null, 1467330000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r70 = new Requisition("CPSC", 6, 7, null, null, 1470010000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r71 = new Requisition("ENGL", 4, 5, null, null, 1472690000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r72 = new Requisition("CPSC", 6, 7, null, null, 1475280000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r73 = new Requisition("CPSC", 15, 7, null, null, 1477960000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r74 = new Requisition("ENGL", 4, 5, null, null, 1480550000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r75 = new Requisition("ENGL", 4, 5, null, null, 1483230000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r76 = new Requisition("ENGL", 14, 5, null, null, 1485910000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r77 = new Requisition("CPSC", 6, 7, null, null, 1488330000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r78 = new Requisition("ENGL", 14, 5, null, null, 1491000000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r79 = new Requisition("CPSC", 6, 7, null, null, 1493600000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r80 = new Requisition("CPSC", 15, 7, null, null, 1496280000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r81 = new Requisition("ENGL", 4, 5, null, null, 1498870000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r82 = new Requisition("ENGL", 4, 5, null, null, 1501550000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r83 = new Requisition("ENGL", 14, 5, null, null, 1504220000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r84 = new Requisition("CPSC", 6, 7, null, null, 1506820000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r85 = new Requisition("ENGL", 4, 5, null, null, 1509490000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r86 = new Requisition("CPSC", 6, 7, null, null, 1512090000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r87 = new Requisition("CPSC", 15, 7, null, null, 1514760000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r88 = new Requisition("ENGL", 4, 5, null, null, 1517440000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r89 = new Requisition("ENGL", 4, 5, null, null, 1519860000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r90 = new Requisition("ENGL", 14, 5, null, null, 1522540000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r91 = new Requisition("CPSC", 6, 7, null, null, 1525130000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r92 = new Requisition("ENGL", 4, 5, null, null, 1527810000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r93 = new Requisition("CPSC", 6, 7, null, null, 1530400000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r94 = new Requisition("CPSC", 15, 7, null, null, 1533080000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r95 = new Requisition("ENGL", 4, 5, null, null, 1535760000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r96 = new Requisition("ENGL", 4, 5, null, null, 1538350000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r97 = new Requisition("ENGL", 14, 5, null, null, 1541030000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r98 = new Requisition("CPSC", 6, 7, null, null, 1543620000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r99 = new Requisition("CPSC", 6, 7, null, null, 1546300000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r100 = new Requisition("ENGL", 4, 5, null, null, 1548980000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r101 = new Requisition("CPSC", 6, 7, null, null, 1551400000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r102 = new Requisition("ENGL", 14, 5, null, null, 1554080000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r103 = new Requisition("ENGL", 4, 5, null, null, 1556670000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r104 = new Requisition("ENGL", 4, 5, null, null, 1559350000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r105 = new Requisition("ENGL", 14, 5, null, null, 1561940000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r106 = new Requisition("CPSC", 6, 7, null, null, 1564620000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r107 = new Requisition("ENGL", 4, 5, null, null, 1567300000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r108 = new Requisition("CPSC", 6, 7, null, null, 1569890000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r109 = new Requisition("CPSC", 15, 7, null, null, 1572570000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            Requisition r110 = new Requisition("ENGL", 4, 5, null, null, 1575160000000, Status.RequsitionStatus.completed, null, null, null, null, null, null);
            dbcontext.Add(r15);
            dbcontext.SaveChanges();
            dbcontext.Add(r16);
            dbcontext.SaveChanges();
            dbcontext.Add(r17);
            dbcontext.SaveChanges();
            dbcontext.Add(r18);
            dbcontext.SaveChanges();
            dbcontext.Add(r19);
            dbcontext.SaveChanges();
            dbcontext.Add(r20);
            dbcontext.SaveChanges();
            dbcontext.Add(r21);
            dbcontext.SaveChanges();
            dbcontext.Add(r22);
            dbcontext.SaveChanges();
            dbcontext.Add(r23);
            dbcontext.SaveChanges();
            dbcontext.Add(r24);
            dbcontext.SaveChanges();
            dbcontext.Add(r25);
            dbcontext.SaveChanges();
            dbcontext.Add(r26);
            dbcontext.SaveChanges();
            dbcontext.Add(r27);
            dbcontext.SaveChanges();
            dbcontext.Add(r28);
            dbcontext.SaveChanges();
            dbcontext.Add(r29);
            dbcontext.SaveChanges();
            dbcontext.Add(r30);
            dbcontext.SaveChanges();
            dbcontext.Add(r31);
            dbcontext.SaveChanges();
            dbcontext.Add(r32);
            dbcontext.SaveChanges();
            dbcontext.Add(r33);
            dbcontext.SaveChanges();
            dbcontext.Add(r34);
            dbcontext.SaveChanges();
            dbcontext.Add(r35);
            dbcontext.SaveChanges();
            dbcontext.Add(r36);
            dbcontext.SaveChanges();
            dbcontext.Add(r37);
            dbcontext.SaveChanges();
            dbcontext.Add(r38);
            dbcontext.SaveChanges();
            dbcontext.Add(r39);
            dbcontext.SaveChanges();
            dbcontext.Add(r40);
            dbcontext.SaveChanges();
            dbcontext.Add(r41);
            dbcontext.SaveChanges();
            dbcontext.Add(r42);
            dbcontext.SaveChanges();
            dbcontext.Add(r43);
            dbcontext.SaveChanges();
            dbcontext.Add(r44);
            dbcontext.SaveChanges();
            dbcontext.Add(r45);
            dbcontext.SaveChanges();
            dbcontext.Add(r46);
            dbcontext.SaveChanges();
            dbcontext.Add(r47);
            dbcontext.SaveChanges();
            dbcontext.Add(r48);
            dbcontext.SaveChanges();
            dbcontext.Add(r49);
            dbcontext.SaveChanges();
            dbcontext.Add(r50);
            dbcontext.SaveChanges();
            dbcontext.Add(r51);
            dbcontext.SaveChanges();
            dbcontext.Add(r52);
            dbcontext.SaveChanges();
            dbcontext.Add(r53);
            dbcontext.SaveChanges();
            dbcontext.Add(r54);
            dbcontext.SaveChanges();
            dbcontext.Add(r55);
            dbcontext.SaveChanges();
            dbcontext.Add(r56);
            dbcontext.SaveChanges();
            dbcontext.Add(r57);
            dbcontext.SaveChanges();
            dbcontext.Add(r58);
            dbcontext.SaveChanges();
            dbcontext.Add(r59);
            dbcontext.SaveChanges();
            dbcontext.Add(r60);
            dbcontext.SaveChanges();
            dbcontext.Add(r61);
            dbcontext.SaveChanges();
            dbcontext.Add(r62);
            dbcontext.SaveChanges();
            dbcontext.Add(r63);
            dbcontext.SaveChanges();
            dbcontext.Add(r64);
            dbcontext.SaveChanges();
            dbcontext.Add(r65);
            dbcontext.SaveChanges();
            dbcontext.Add(r66);
            dbcontext.SaveChanges();
            dbcontext.Add(r67);
            dbcontext.SaveChanges();
            dbcontext.Add(r68);
            dbcontext.SaveChanges();
            dbcontext.Add(r69);
            dbcontext.SaveChanges();
            dbcontext.Add(r70);
            dbcontext.SaveChanges();
            dbcontext.Add(r71);
            dbcontext.SaveChanges();
            dbcontext.Add(r72);
            dbcontext.SaveChanges();
            dbcontext.Add(r73);
            dbcontext.SaveChanges();
            dbcontext.Add(r74);
            dbcontext.SaveChanges();
            dbcontext.Add(r75);
            dbcontext.SaveChanges();
            dbcontext.Add(r76);
            dbcontext.SaveChanges();
            dbcontext.Add(r77);
            dbcontext.SaveChanges();
            dbcontext.Add(r78);
            dbcontext.SaveChanges();
            dbcontext.Add(r79);
            dbcontext.SaveChanges();
            dbcontext.Add(r80);
            dbcontext.SaveChanges();
            dbcontext.Add(r81);
            dbcontext.SaveChanges();
            dbcontext.Add(r82);
            dbcontext.SaveChanges();
            dbcontext.Add(r83);
            dbcontext.SaveChanges();
            dbcontext.Add(r84);
            dbcontext.SaveChanges();
            dbcontext.Add(r85);
            dbcontext.SaveChanges();
            dbcontext.Add(r86);
            dbcontext.SaveChanges();
            dbcontext.Add(r87);
            dbcontext.SaveChanges();
            dbcontext.Add(r88);
            dbcontext.SaveChanges();
            dbcontext.Add(r89);
            dbcontext.SaveChanges();
            dbcontext.Add(r90);
            dbcontext.SaveChanges();
            dbcontext.Add(r91);
            dbcontext.SaveChanges();
            dbcontext.Add(r92);
            dbcontext.SaveChanges();
            dbcontext.Add(r93);
            dbcontext.SaveChanges();
            dbcontext.Add(r94);
            dbcontext.SaveChanges();
            dbcontext.Add(r95);
            dbcontext.SaveChanges();
            dbcontext.Add(r96);
            dbcontext.SaveChanges();
            dbcontext.Add(r97);
            dbcontext.SaveChanges();
            dbcontext.Add(r98);
            dbcontext.SaveChanges();
            dbcontext.Add(r99);
            dbcontext.SaveChanges();
            dbcontext.Add(r100);
            dbcontext.SaveChanges();
            dbcontext.Add(r101);
            dbcontext.SaveChanges();
            dbcontext.Add(r102);
            dbcontext.SaveChanges();
            dbcontext.Add(r103);
            dbcontext.SaveChanges();
            dbcontext.Add(r104);
            dbcontext.SaveChanges();
            dbcontext.Add(r105);
            dbcontext.SaveChanges();
            dbcontext.Add(r106);
            dbcontext.SaveChanges();
            dbcontext.Add(r107);
            dbcontext.SaveChanges();
            dbcontext.Add(r108);
            dbcontext.SaveChanges();
            dbcontext.Add(r109);
            dbcontext.SaveChanges();
            dbcontext.Add(r110);
            dbcontext.SaveChanges();
            //End of Requisition from CSV Seeder

            //seed requsition detail
            //public RequisitionDetail(int RequisitionId, string ProductId, int QtyNeeded, int? QtyDisbursed, int? QtyReceived,
            //string? DisburseRemark, string? RepRemark, string? ClerkRemark, int? RetrievalId)
            RequisitionDetail rd1 = new RequisitionDetail(1, "C001", 50);
            dbcontext.Add(rd1);
            dbcontext.SaveChanges();
            RequisitionDetail rd2 = new RequisitionDetail(2, "C001", 15);
            dbcontext.Add(rd2);
            dbcontext.SaveChanges();
            RequisitionDetail rd25 = new RequisitionDetail(4, "C001", 15, 15, null, null, null, null, 2);
            dbcontext.Add(rd25);
            dbcontext.SaveChanges();
            //RequisitionDetail rd3 = new RequisitionDetail(5, "C001", 10, 10, 10, null, null, null, 1);//refer to retr1
            //dbcontext.Add(rd3);
            //dbcontext.SaveChanges();
            //RequisitionDetail rd4 = new RequisitionDetail(5, "C001", 50, 50, 50, null, null, null, 1);//retr1
            //dbcontext.Add(rd4);
            //dbcontext.SaveChanges();
            //RequisitionDetail rd5 = new RequisitionDetail(5, "P043", 20, 20, 20, null, null, null, 2);//retr2
            //dbcontext.Add(rd5);
            //dbcontext.SaveChanges();
            //RequisitionDetail rd6 = new RequisitionDetail(6, "P043", 50, 50, 50, null, null, null, 3);//retr3
            //dbcontext.Add(rd6);
            //dbcontext.SaveChanges();
            //RequisitionDetail rd7 = new RequisitionDetail(6, "C001", 10, 8, 8, "only 8 left", "noted", null, 3);//retr3
            //dbcontext.Add(rd7);
            //dbcontext.SaveChanges();
            //RequisitionDetail rd8 = new RequisitionDetail(7, "P043", 30, 30, 28, null, "2 spoilt during delivery", "confirmed", 3); //sub need to raise 2 in voucher
            //dbcontext.Add(rd8);
            //dbcontext.SaveChanges();
            //RequisitionDetail rd9 = new RequisitionDetail(7, "C001", 10, 10, 10, null, null, null, 3);
            //dbcontext.Add(rd9);
            //dbcontext.SaveChanges();

            RequisitionDetail rd10 = new RequisitionDetail(5, "C001", 10);
            dbcontext.Add(rd10);
            dbcontext.SaveChanges();
            RequisitionDetail rd11 = new RequisitionDetail(5, "F021", 10);
            dbcontext.Add(rd11);
            dbcontext.SaveChanges();
            RequisitionDetail rd12 = new RequisitionDetail(5, "P010", 10);
            dbcontext.Add(rd12);
            dbcontext.SaveChanges();

            RequisitionDetail rd13 = new RequisitionDetail(6, "C001", 5);
            dbcontext.Add(rd13);
            dbcontext.SaveChanges();
            RequisitionDetail rd14 = new RequisitionDetail(6, "F021", 5);
            dbcontext.Add(rd14);
            dbcontext.SaveChanges();
            RequisitionDetail rd15 = new RequisitionDetail(6, "P010", 5);
            dbcontext.Add(rd15);
            dbcontext.SaveChanges();

            RequisitionDetail rd16 = new RequisitionDetail(7, "C004", 5);
            dbcontext.Add(rd16);
            dbcontext.SaveChanges();
            RequisitionDetail rd17 = new RequisitionDetail(7, "F020", 5);
            dbcontext.Add(rd17);
            dbcontext.SaveChanges();
            RequisitionDetail rd18 = new RequisitionDetail(7, "P011", 10);
            dbcontext.Add(rd18);
            dbcontext.SaveChanges();

            RequisitionDetail rd19 = new RequisitionDetail(8, "C001", 5, 5, null, null, null, null, 3);
            dbcontext.Add(rd19);
            dbcontext.SaveChanges();
            RequisitionDetail rd20 = new RequisitionDetail(8, "P011", 10, 9, null, "Only 9 items left", null, null, 3);
            dbcontext.Add(rd20);
            dbcontext.SaveChanges();

            RequisitionDetail rd21 = new RequisitionDetail(9, "C001", 10);
            dbcontext.Add(rd21);
            dbcontext.SaveChanges();
            RequisitionDetail rd22 = new RequisitionDetail(9, "E032", 10);
            dbcontext.Add(rd22);
            dbcontext.SaveChanges();

            RequisitionDetail rd23 = new RequisitionDetail(10, "C001", 5);
            dbcontext.Add(rd23);
            dbcontext.SaveChanges();
            RequisitionDetail rd24 = new RequisitionDetail(10, "E032", 6);
            dbcontext.Add(rd24);
            dbcontext.SaveChanges();

            RequisitionDetail rd26 = new RequisitionDetail(11, "C001", 20);
            dbcontext.Add(rd26);
            dbcontext.SaveChanges();
            RequisitionDetail rd27 = new RequisitionDetail(11, "E032", 20);
            dbcontext.Add(rd27);
            dbcontext.SaveChanges();

            RequisitionDetail rd28 = new RequisitionDetail(3, "F021",10, 10, null, null, null, null, 2);
            dbcontext.Add(rd28);
            dbcontext.SaveChanges();
            RequisitionDetail rd29 = new RequisitionDetail(3, "D001", 5, 5, null, null, null, null, 2);
            dbcontext.Add(rd29);
            dbcontext.SaveChanges();

            RequisitionDetail rd30 = new RequisitionDetail(12, "C001", 5, 5, null, null, null, null, 3);
            dbcontext.Add(rd30);
            dbcontext.SaveChanges();
            RequisitionDetail rd31 = new RequisitionDetail(12, "D001", 5, 5, null, null, null, null, 3);
            dbcontext.Add(rd31);
            dbcontext.SaveChanges();

            RequisitionDetail rd32 = new RequisitionDetail(13, "C004", 5,5, null, null, null, null, 1);
            dbcontext.Add(rd32);
            dbcontext.SaveChanges();
            RequisitionDetail rd33 = new RequisitionDetail(13, "H013", 5,5, null, null, null, null, 1);
            dbcontext.Add(rd33);
            dbcontext.SaveChanges();

            RequisitionDetail rd34 = new RequisitionDetail(14, "P012", 5,5, null, null, null, null, 1);
            dbcontext.Add(rd34);
            dbcontext.SaveChanges();
            RequisitionDetail rd35 = new RequisitionDetail(14, "E031", 5,5, null, null, null, null, 1);
            dbcontext.Add(rd35);
            dbcontext.SaveChanges();

            //RequisitionDetail CSV Seeder
            RequisitionDetail rd36 = new RequisitionDetail(15, "C001", 2470, 2470, 2470, null, null, null, null);
            RequisitionDetail rd37 = new RequisitionDetail(16, "C001", 1180, 1180, 1180, null, null, null, null);
            RequisitionDetail rd38 = new RequisitionDetail(17, "C001", 1320, 1320, 1320, null, null, null, null);
            RequisitionDetail rd39 = new RequisitionDetail(18, "C001", 1290, 1290, 1290, null, null, null, null);
            RequisitionDetail rd40 = new RequisitionDetail(19, "C001", 1210, 1210, 1210, null, null, null, null);
            RequisitionDetail rd41 = new RequisitionDetail(20, "C001", 130, 130, 130, null, null, null, null);
            RequisitionDetail rd42 = new RequisitionDetail(21, "C001", 140, 140, 140, null, null, null, null);
            RequisitionDetail rd43 = new RequisitionDetail(22, "C001", 2680, 2680, 2680, null, null, null, null);
            RequisitionDetail rd44 = new RequisitionDetail(23, "C001", 1360, 1360, 1360, null, null, null, null);
            RequisitionDetail rd45 = new RequisitionDetail(24, "C001", 1190, 1190, 1190, null, null, null, null);
            RequisitionDetail rd46 = new RequisitionDetail(25, "C001", 1040, 1040, 1040, null, null, null, null);
            RequisitionDetail rd47 = new RequisitionDetail(26, "C001", 430, 430, 430, null, null, null, null);
            RequisitionDetail rd48 = new RequisitionDetail(27, "C001", 2540, 2540, 2540, null, null, null, null);
            RequisitionDetail rd49 = new RequisitionDetail(28, "C001", 1250, 1250, 1250, null, null, null, null);
            RequisitionDetail rd50 = new RequisitionDetail(29, "C001", 1390, 1390, 1390, null, null, null, null);
            RequisitionDetail rd51 = new RequisitionDetail(30, "C001", 1360, 1360, 1360, null, null, null, null);
            RequisitionDetail rd52 = new RequisitionDetail(31, "C001", 1280, 1280, 1280, null, null, null, null);
            RequisitionDetail rd53 = new RequisitionDetail(32, "C001", 200, 200, 200, null, null, null, null);
            RequisitionDetail rd54 = new RequisitionDetail(33, "C001", 210, 210, 210, null, null, null, null);
            RequisitionDetail rd55 = new RequisitionDetail(34, "C001", 2750, 2750, 2750, null, null, null, null);
            RequisitionDetail rd56 = new RequisitionDetail(35, "C001", 1430, 1430, 1430, null, null, null, null);
            RequisitionDetail rd57 = new RequisitionDetail(36, "C001", 1260, 1260, 1260, null, null, null, null);
            RequisitionDetail rd58 = new RequisitionDetail(37, "C001", 1110, 1110, 1110, null, null, null, null);
            RequisitionDetail rd59 = new RequisitionDetail(38, "C001", 500, 500, 500, null, null, null, null);
            RequisitionDetail rd60 = new RequisitionDetail(39, "C001", 2610, 2610, 2610, null, null, null, null);
            RequisitionDetail rd61 = new RequisitionDetail(40, "C001", 1320, 1320, 1320, null, null, null, null);
            RequisitionDetail rd62 = new RequisitionDetail(41, "C001", 1460, 1460, 1460, null, null, null, null);
            RequisitionDetail rd63 = new RequisitionDetail(42, "C001", 1430, 1430, 1430, null, null, null, null);
            RequisitionDetail rd64 = new RequisitionDetail(43, "C001", 1350, 1350, 1350, null, null, null, null);
            RequisitionDetail rd65 = new RequisitionDetail(44, "C001", 270, 270, 270, null, null, null, null);
            RequisitionDetail rd66 = new RequisitionDetail(45, "C001", 280, 280, 280, null, null, null, null);
            RequisitionDetail rd67 = new RequisitionDetail(46, "C001", 2820, 2820, 2820, null, null, null, null);
            RequisitionDetail rd68 = new RequisitionDetail(47, "C001", 1500, 1500, 1500, null, null, null, null);
            RequisitionDetail rd69 = new RequisitionDetail(48, "C001", 1330, 1330, 1330, null, null, null, null);
            RequisitionDetail rd70 = new RequisitionDetail(49, "C001", 1180, 1180, 1180, null, null, null, null);
            RequisitionDetail rd71 = new RequisitionDetail(50, "C001", 570, 570, 570, null, null, null, null);
            RequisitionDetail rd72 = new RequisitionDetail(51, "C001", 2730, 2730, 2730, null, null, null, null);
            RequisitionDetail rd73 = new RequisitionDetail(52, "C001", 1440, 1440, 1440, null, null, null, null);
            RequisitionDetail rd74 = new RequisitionDetail(53, "C001", 1580, 1580, 1580, null, null, null, null);
            RequisitionDetail rd75 = new RequisitionDetail(54, "C001", 1550, 1550, 1550, null, null, null, null);
            RequisitionDetail rd76 = new RequisitionDetail(55, "C001", 1470, 1470, 1470, null, null, null, null);
            RequisitionDetail rd77 = new RequisitionDetail(56, "C001", 390, 390, 390, null, null, null, null);
            RequisitionDetail rd78 = new RequisitionDetail(57, "C001", 400, 400, 400, null, null, null, null);
            RequisitionDetail rd79 = new RequisitionDetail(58, "C001", 2940, 2940, 2940, null, null, null, null);
            RequisitionDetail rd80 = new RequisitionDetail(59, "C001", 1620, 1620, 1620, null, null, null, null);
            RequisitionDetail rd81 = new RequisitionDetail(60, "C001", 1450, 1450, 1450, null, null, null, null);
            RequisitionDetail rd82 = new RequisitionDetail(61, "C001", 1300, 1300, 1300, null, null, null, null);
            RequisitionDetail rd83 = new RequisitionDetail(62, "C001", 690, 690, 690, null, null, null, null);
            RequisitionDetail rd84 = new RequisitionDetail(63, "C001", 2730, 2730, 2730, null, null, null, null);
            RequisitionDetail rd85 = new RequisitionDetail(64, "C001", 1440, 1440, 1440, null, null, null, null);
            RequisitionDetail rd86 = new RequisitionDetail(65, "C001", 1580, 1580, 1580, null, null, null, null);
            RequisitionDetail rd87 = new RequisitionDetail(66, "C001", 1550, 1550, 1550, null, null, null, null);
            RequisitionDetail rd88 = new RequisitionDetail(67, "C001", 1470, 1470, 1470, null, null, null, null);
            RequisitionDetail rd89 = new RequisitionDetail(68, "C001", 390, 390, 390, null, null, null, null);
            RequisitionDetail rd90 = new RequisitionDetail(69, "C001", 400, 400, 400, null, null, null, null);
            RequisitionDetail rd91 = new RequisitionDetail(70, "C001", 2940, 2940, 2940, null, null, null, null);
            RequisitionDetail rd92 = new RequisitionDetail(71, "C001", 1620, 1620, 1620, null, null, null, null);
            RequisitionDetail rd93 = new RequisitionDetail(72, "C001", 1450, 1450, 1450, null, null, null, null);
            RequisitionDetail rd94 = new RequisitionDetail(73, "C001", 1300, 1300, 1300, null, null, null, null);
            RequisitionDetail rd95 = new RequisitionDetail(74, "C001", 690, 690, 690, null, null, null, null);
            RequisitionDetail rd96 = new RequisitionDetail(75, "C001", 2870, 2870, 2870, null, null, null, null);
            RequisitionDetail rd97 = new RequisitionDetail(76, "C001", 1580, 1580, 1580, null, null, null, null);
            RequisitionDetail rd98 = new RequisitionDetail(77, "C001", 1720, 1720, 1720, null, null, null, null);
            RequisitionDetail rd99 = new RequisitionDetail(78, "C001", 1690, 1690, 1690, null, null, null, null);
            RequisitionDetail rd100 = new RequisitionDetail(79, "C001", 1610, 1610, 1610, null, null, null, null);
            RequisitionDetail rd101 = new RequisitionDetail(80, "C001", 530, 530, 530, null, null, null, null);
            RequisitionDetail rd102 = new RequisitionDetail(81, "C001", 540, 540, 540, null, null, null, null);
            RequisitionDetail rd103 = new RequisitionDetail(82, "C001", 3080, 3080, 3080, null, null, null, null);
            RequisitionDetail rd104 = new RequisitionDetail(83, "C001", 1760, 1760, 1760, null, null, null, null);
            RequisitionDetail rd105 = new RequisitionDetail(84, "C001", 1590, 1590, 1590, null, null, null, null);
            RequisitionDetail rd106 = new RequisitionDetail(85, "C001", 1440, 1440, 1440, null, null, null, null);
            RequisitionDetail rd107 = new RequisitionDetail(86, "C001", 830, 830, 830, null, null, null, null);
            RequisitionDetail rd108 = new RequisitionDetail(87, "C001", 3020, 3020, 3020, null, null, null, null);
            RequisitionDetail rd109 = new RequisitionDetail(88, "C001", 1730, 1730, 1730, null, null, null, null);
            RequisitionDetail rd110 = new RequisitionDetail(89, "C001", 1870, 1870, 1870, null, null, null, null);
            RequisitionDetail rd111 = new RequisitionDetail(90, "C001", 1840, 1840, 1840, null, null, null, null);
            RequisitionDetail rd112 = new RequisitionDetail(91, "C001", 1760, 1760, 1760, null, null, null, null);
            RequisitionDetail rd113 = new RequisitionDetail(92, "C001", 680, 680, 680, null, null, null, null);
            RequisitionDetail rd114 = new RequisitionDetail(93, "C001", 690, 690, 690, null, null, null, null);
            RequisitionDetail rd115 = new RequisitionDetail(94, "C001", 3230, 3230, 3230, null, null, null, null);
            RequisitionDetail rd116 = new RequisitionDetail(95, "C001", 1910, 1910, 1910, null, null, null, null);
            RequisitionDetail rd117 = new RequisitionDetail(96, "C001", 1740, 1740, 1740, null, null, null, null);
            RequisitionDetail rd118 = new RequisitionDetail(97, "C001", 1590, 1590, 1590, null, null, null, null);
            RequisitionDetail rd119 = new RequisitionDetail(98, "C001", 980, 980, 980, null, null, null, null);
            RequisitionDetail rd120 = new RequisitionDetail(99, "C001", 3090, 3090, 3090, null, null, null, null);
            RequisitionDetail rd121 = new RequisitionDetail(100, "C001", 1800, 1800, 1800, null, null, null, null);
            RequisitionDetail rd122 = new RequisitionDetail(101, "C001", 1940, 1940, 1940, null, null, null, null);
            RequisitionDetail rd123 = new RequisitionDetail(102, "C001", 1910, 1910, 1910, null, null, null, null);
            RequisitionDetail rd124 = new RequisitionDetail(103, "C001", 1830, 1830, 1830, null, null, null, null);
            RequisitionDetail rd125 = new RequisitionDetail(104, "C001", 750, 750, 750, null, null, null, null);
            RequisitionDetail rd126 = new RequisitionDetail(105, "C001", 760, 760, 760, null, null, null, null);
            RequisitionDetail rd127 = new RequisitionDetail(106, "C001", 3300, 3300, 3300, null, null, null, null);
            RequisitionDetail rd128 = new RequisitionDetail(107, "C001", 1980, 1980, 1980, null, null, null, null);
            RequisitionDetail rd129 = new RequisitionDetail(108, "C001", 1810, 1810, 1810, null, null, null, null);
            RequisitionDetail rd130 = new RequisitionDetail(109, "C001", 1660, 1660, 1660, null, null, null, null);
            RequisitionDetail rd131 = new RequisitionDetail(110, "C001", 1050, 1050, 1050, null, null, null, null);
            RequisitionDetail rd132 = new RequisitionDetail(15, "C002", 247, 247, 247, null, null, null, null);
            RequisitionDetail rd133 = new RequisitionDetail(16, "C002", 118, 118, 118, null, null, null, null);
            RequisitionDetail rd134 = new RequisitionDetail(17, "C002", 132, 132, 132, null, null, null, null);
            RequisitionDetail rd135 = new RequisitionDetail(18, "C002", 129, 129, 129, null, null, null, null);
            RequisitionDetail rd136 = new RequisitionDetail(19, "C002", 121, 121, 121, null, null, null, null);
            RequisitionDetail rd137 = new RequisitionDetail(20, "C002", 13, 13, 13, null, null, null, null);
            RequisitionDetail rd138 = new RequisitionDetail(21, "C002", 14, 14, 14, null, null, null, null);
            RequisitionDetail rd139 = new RequisitionDetail(22, "C002", 268, 268, 268, null, null, null, null);
            RequisitionDetail rd140 = new RequisitionDetail(23, "C002", 136, 136, 136, null, null, null, null);
            RequisitionDetail rd141 = new RequisitionDetail(24, "C002", 119, 119, 119, null, null, null, null);
            RequisitionDetail rd142 = new RequisitionDetail(25, "C002", 104, 104, 104, null, null, null, null);
            RequisitionDetail rd143 = new RequisitionDetail(26, "C002", 43, 43, 43, null, null, null, null);
            RequisitionDetail rd144 = new RequisitionDetail(27, "C002", 254, 254, 254, null, null, null, null);
            RequisitionDetail rd145 = new RequisitionDetail(28, "C002", 125, 125, 125, null, null, null, null);
            RequisitionDetail rd146 = new RequisitionDetail(29, "C002", 139, 139, 139, null, null, null, null);
            RequisitionDetail rd147 = new RequisitionDetail(30, "C002", 136, 136, 136, null, null, null, null);
            RequisitionDetail rd148 = new RequisitionDetail(31, "C002", 128, 128, 128, null, null, null, null);
            RequisitionDetail rd149 = new RequisitionDetail(32, "C002", 20, 20, 20, null, null, null, null);
            RequisitionDetail rd150 = new RequisitionDetail(33, "C002", 21, 21, 21, null, null, null, null);
            RequisitionDetail rd151 = new RequisitionDetail(34, "C002", 275, 275, 275, null, null, null, null);
            RequisitionDetail rd152 = new RequisitionDetail(35, "C002", 143, 143, 143, null, null, null, null);
            RequisitionDetail rd153 = new RequisitionDetail(36, "C002", 126, 126, 126, null, null, null, null);
            RequisitionDetail rd154 = new RequisitionDetail(37, "C002", 111, 111, 111, null, null, null, null);
            RequisitionDetail rd155 = new RequisitionDetail(38, "C002", 50, 50, 50, null, null, null, null);
            RequisitionDetail rd156 = new RequisitionDetail(39, "C002", 261, 261, 261, null, null, null, null);
            RequisitionDetail rd157 = new RequisitionDetail(40, "C002", 132, 132, 132, null, null, null, null);
            RequisitionDetail rd158 = new RequisitionDetail(41, "C002", 146, 146, 146, null, null, null, null);
            RequisitionDetail rd159 = new RequisitionDetail(42, "C002", 143, 143, 143, null, null, null, null);
            RequisitionDetail rd160 = new RequisitionDetail(43, "C002", 135, 135, 135, null, null, null, null);
            RequisitionDetail rd161 = new RequisitionDetail(44, "C002", 27, 27, 27, null, null, null, null);
            RequisitionDetail rd162 = new RequisitionDetail(45, "C002", 28, 28, 28, null, null, null, null);
            RequisitionDetail rd163 = new RequisitionDetail(46, "C002", 282, 282, 282, null, null, null, null);
            RequisitionDetail rd164 = new RequisitionDetail(47, "C002", 150, 150, 150, null, null, null, null);
            RequisitionDetail rd165 = new RequisitionDetail(48, "C002", 133, 133, 133, null, null, null, null);
            RequisitionDetail rd166 = new RequisitionDetail(49, "C002", 118, 118, 118, null, null, null, null);
            RequisitionDetail rd167 = new RequisitionDetail(50, "C002", 57, 57, 57, null, null, null, null);
            RequisitionDetail rd168 = new RequisitionDetail(51, "C002", 273, 273, 273, null, null, null, null);
            RequisitionDetail rd169 = new RequisitionDetail(52, "C002", 144, 144, 144, null, null, null, null);
            RequisitionDetail rd170 = new RequisitionDetail(53, "C002", 158, 158, 158, null, null, null, null);
            RequisitionDetail rd171 = new RequisitionDetail(54, "C002", 155, 155, 155, null, null, null, null);
            RequisitionDetail rd172 = new RequisitionDetail(55, "C002", 147, 147, 147, null, null, null, null);
            RequisitionDetail rd173 = new RequisitionDetail(56, "C002", 39, 39, 39, null, null, null, null);
            RequisitionDetail rd174 = new RequisitionDetail(57, "C002", 40, 40, 40, null, null, null, null);
            RequisitionDetail rd175 = new RequisitionDetail(58, "C002", 294, 294, 294, null, null, null, null);
            RequisitionDetail rd176 = new RequisitionDetail(59, "C002", 162, 162, 162, null, null, null, null);
            RequisitionDetail rd177 = new RequisitionDetail(60, "C002", 145, 145, 145, null, null, null, null);
            RequisitionDetail rd178 = new RequisitionDetail(61, "C002", 130, 130, 130, null, null, null, null);
            RequisitionDetail rd179 = new RequisitionDetail(62, "C002", 69, 69, 69, null, null, null, null);
            RequisitionDetail rd180 = new RequisitionDetail(63, "C002", 273, 273, 273, null, null, null, null);
            RequisitionDetail rd181 = new RequisitionDetail(64, "C002", 144, 144, 144, null, null, null, null);
            RequisitionDetail rd182 = new RequisitionDetail(65, "C002", 158, 158, 158, null, null, null, null);
            RequisitionDetail rd183 = new RequisitionDetail(66, "C002", 155, 155, 155, null, null, null, null);
            RequisitionDetail rd184 = new RequisitionDetail(67, "C002", 147, 147, 147, null, null, null, null);
            RequisitionDetail rd185 = new RequisitionDetail(68, "C002", 39, 39, 39, null, null, null, null);
            RequisitionDetail rd186 = new RequisitionDetail(69, "C002", 40, 40, 40, null, null, null, null);
            RequisitionDetail rd187 = new RequisitionDetail(70, "C002", 294, 294, 294, null, null, null, null);
            RequisitionDetail rd188 = new RequisitionDetail(71, "C002", 162, 162, 162, null, null, null, null);
            RequisitionDetail rd189 = new RequisitionDetail(72, "C002", 145, 145, 145, null, null, null, null);
            RequisitionDetail rd190 = new RequisitionDetail(73, "C002", 130, 130, 130, null, null, null, null);
            RequisitionDetail rd191 = new RequisitionDetail(74, "C002", 69, 69, 69, null, null, null, null);
            RequisitionDetail rd192 = new RequisitionDetail(75, "C002", 287, 287, 287, null, null, null, null);
            RequisitionDetail rd193 = new RequisitionDetail(76, "C002", 158, 158, 158, null, null, null, null);
            RequisitionDetail rd194 = new RequisitionDetail(77, "C002", 172, 172, 172, null, null, null, null);
            RequisitionDetail rd195 = new RequisitionDetail(78, "C002", 169, 169, 169, null, null, null, null);
            RequisitionDetail rd196 = new RequisitionDetail(79, "C002", 161, 161, 161, null, null, null, null);
            RequisitionDetail rd197 = new RequisitionDetail(80, "C002", 53, 53, 53, null, null, null, null);
            RequisitionDetail rd198 = new RequisitionDetail(81, "C002", 54, 54, 54, null, null, null, null);
            RequisitionDetail rd199 = new RequisitionDetail(82, "C002", 308, 308, 308, null, null, null, null);
            RequisitionDetail rd200 = new RequisitionDetail(83, "C002", 176, 176, 176, null, null, null, null);
            RequisitionDetail rd201 = new RequisitionDetail(84, "C002", 159, 159, 159, null, null, null, null);
            RequisitionDetail rd202 = new RequisitionDetail(85, "C002", 144, 144, 144, null, null, null, null);
            RequisitionDetail rd203 = new RequisitionDetail(86, "C002", 83, 83, 83, null, null, null, null);
            RequisitionDetail rd204 = new RequisitionDetail(87, "C002", 302, 302, 302, null, null, null, null);
            RequisitionDetail rd205 = new RequisitionDetail(88, "C002", 173, 173, 173, null, null, null, null);
            RequisitionDetail rd206 = new RequisitionDetail(89, "C002", 187, 187, 187, null, null, null, null);
            RequisitionDetail rd207 = new RequisitionDetail(90, "C002", 184, 184, 184, null, null, null, null);
            RequisitionDetail rd208 = new RequisitionDetail(91, "C002", 176, 176, 176, null, null, null, null);
            RequisitionDetail rd209 = new RequisitionDetail(92, "C002", 68, 68, 68, null, null, null, null);
            RequisitionDetail rd210 = new RequisitionDetail(93, "C002", 69, 69, 69, null, null, null, null);
            RequisitionDetail rd211 = new RequisitionDetail(94, "C002", 323, 323, 323, null, null, null, null);
            RequisitionDetail rd212 = new RequisitionDetail(95, "C002", 191, 191, 191, null, null, null, null);
            RequisitionDetail rd213 = new RequisitionDetail(96, "C002", 174, 174, 174, null, null, null, null);
            RequisitionDetail rd214 = new RequisitionDetail(97, "C002", 159, 159, 159, null, null, null, null);
            RequisitionDetail rd215 = new RequisitionDetail(98, "C002", 98, 98, 98, null, null, null, null);
            RequisitionDetail rd216 = new RequisitionDetail(99, "C002", 309, 309, 309, null, null, null, null);
            RequisitionDetail rd217 = new RequisitionDetail(100, "C002", 180, 180, 180, null, null, null, null);
            RequisitionDetail rd218 = new RequisitionDetail(101, "C002", 194, 194, 194, null, null, null, null);
            RequisitionDetail rd219 = new RequisitionDetail(102, "C002", 191, 191, 191, null, null, null, null);
            RequisitionDetail rd220 = new RequisitionDetail(103, "C002", 183, 183, 183, null, null, null, null);
            RequisitionDetail rd221 = new RequisitionDetail(104, "C002", 75, 75, 75, null, null, null, null);
            RequisitionDetail rd222 = new RequisitionDetail(105, "C002", 76, 76, 76, null, null, null, null);
            RequisitionDetail rd223 = new RequisitionDetail(106, "C002", 330, 330, 330, null, null, null, null);
            RequisitionDetail rd224 = new RequisitionDetail(107, "C002", 198, 198, 198, null, null, null, null);
            RequisitionDetail rd225 = new RequisitionDetail(108, "C002", 181, 181, 181, null, null, null, null);
            RequisitionDetail rd226 = new RequisitionDetail(109, "C002", 166, 166, 166, null, null, null, null);
            RequisitionDetail rd227 = new RequisitionDetail(110, "C002", 105, 105, 105, null, null, null, null);
            RequisitionDetail rd228 = new RequisitionDetail(15, "P043", 4940, 4940, 4940, null, null, null, null);
            RequisitionDetail rd229 = new RequisitionDetail(16, "P043", 2360, 2360, 2360, null, null, null, null);
            RequisitionDetail rd230 = new RequisitionDetail(17, "P043", 2640, 2640, 2640, null, null, null, null);
            RequisitionDetail rd231 = new RequisitionDetail(18, "P043", 2580, 2580, 2580, null, null, null, null);
            RequisitionDetail rd232 = new RequisitionDetail(19, "P043", 2420, 2420, 2420, null, null, null, null);
            RequisitionDetail rd233 = new RequisitionDetail(20, "P043", 260, 260, 260, null, null, null, null);
            RequisitionDetail rd234 = new RequisitionDetail(21, "P043", 280, 280, 280, null, null, null, null);
            RequisitionDetail rd235 = new RequisitionDetail(22, "P043", 5360, 5360, 5360, null, null, null, null);
            RequisitionDetail rd236 = new RequisitionDetail(23, "P043", 2720, 2720, 2720, null, null, null, null);
            RequisitionDetail rd237 = new RequisitionDetail(24, "P043", 2380, 2380, 2380, null, null, null, null);
            RequisitionDetail rd238 = new RequisitionDetail(25, "P043", 2080, 2080, 2080, null, null, null, null);
            RequisitionDetail rd239 = new RequisitionDetail(26, "P043", 860, 860, 860, null, null, null, null);
            RequisitionDetail rd240 = new RequisitionDetail(27, "P043", 5080, 5080, 5080, null, null, null, null);
            RequisitionDetail rd241 = new RequisitionDetail(28, "P043", 2500, 2500, 2500, null, null, null, null);
            RequisitionDetail rd242 = new RequisitionDetail(29, "P043", 2780, 2780, 2780, null, null, null, null);
            RequisitionDetail rd243 = new RequisitionDetail(30, "P043", 2720, 2720, 2720, null, null, null, null);
            RequisitionDetail rd244 = new RequisitionDetail(31, "P043", 2560, 2560, 2560, null, null, null, null);
            RequisitionDetail rd245 = new RequisitionDetail(32, "P043", 400, 400, 400, null, null, null, null);
            RequisitionDetail rd246 = new RequisitionDetail(33, "P043", 420, 420, 420, null, null, null, null);
            RequisitionDetail rd247 = new RequisitionDetail(34, "P043", 5500, 5500, 5500, null, null, null, null);
            RequisitionDetail rd248 = new RequisitionDetail(35, "P043", 2860, 2860, 2860, null, null, null, null);
            RequisitionDetail rd249 = new RequisitionDetail(36, "P043", 2520, 2520, 2520, null, null, null, null);
            RequisitionDetail rd250 = new RequisitionDetail(37, "P043", 2220, 2220, 2220, null, null, null, null);
            RequisitionDetail rd251 = new RequisitionDetail(38, "P043", 1000, 1000, 1000, null, null, null, null);
            RequisitionDetail rd252 = new RequisitionDetail(39, "P043", 5220, 5220, 5220, null, null, null, null);
            RequisitionDetail rd253 = new RequisitionDetail(40, "P043", 2640, 2640, 2640, null, null, null, null);
            RequisitionDetail rd254 = new RequisitionDetail(41, "P043", 2920, 2920, 2920, null, null, null, null);
            RequisitionDetail rd255 = new RequisitionDetail(42, "P043", 2860, 2860, 2860, null, null, null, null);
            RequisitionDetail rd256 = new RequisitionDetail(43, "P043", 2700, 2700, 2700, null, null, null, null);
            RequisitionDetail rd257 = new RequisitionDetail(44, "P043", 540, 540, 540, null, null, null, null);
            RequisitionDetail rd258 = new RequisitionDetail(45, "P043", 560, 560, 560, null, null, null, null);
            RequisitionDetail rd259 = new RequisitionDetail(46, "P043", 5640, 5640, 5640, null, null, null, null);
            RequisitionDetail rd260 = new RequisitionDetail(47, "P043", 3000, 3000, 3000, null, null, null, null);
            RequisitionDetail rd261 = new RequisitionDetail(48, "P043", 2660, 2660, 2660, null, null, null, null);
            RequisitionDetail rd262 = new RequisitionDetail(49, "P043", 2360, 2360, 2360, null, null, null, null);
            RequisitionDetail rd263 = new RequisitionDetail(50, "P043", 1140, 1140, 1140, null, null, null, null);
            RequisitionDetail rd264 = new RequisitionDetail(51, "P043", 5460, 5460, 5460, null, null, null, null);
            RequisitionDetail rd265 = new RequisitionDetail(52, "P043", 2880, 2880, 2880, null, null, null, null);
            RequisitionDetail rd266 = new RequisitionDetail(53, "P043", 3160, 3160, 3160, null, null, null, null);
            RequisitionDetail rd267 = new RequisitionDetail(54, "P043", 3100, 3100, 3100, null, null, null, null);
            RequisitionDetail rd268 = new RequisitionDetail(55, "P043", 2940, 2940, 2940, null, null, null, null);
            RequisitionDetail rd269 = new RequisitionDetail(56, "P043", 780, 780, 780, null, null, null, null);
            RequisitionDetail rd270 = new RequisitionDetail(57, "P043", 800, 800, 800, null, null, null, null);
            RequisitionDetail rd271 = new RequisitionDetail(58, "P043", 5880, 5880, 5880, null, null, null, null);
            RequisitionDetail rd272 = new RequisitionDetail(59, "P043", 3240, 3240, 3240, null, null, null, null);
            RequisitionDetail rd273 = new RequisitionDetail(60, "P043", 2900, 2900, 2900, null, null, null, null);
            RequisitionDetail rd274 = new RequisitionDetail(61, "P043", 2600, 2600, 2600, null, null, null, null);
            RequisitionDetail rd275 = new RequisitionDetail(62, "P043", 1380, 1380, 1380, null, null, null, null);
            RequisitionDetail rd276 = new RequisitionDetail(63, "P043", 5460, 5460, 5460, null, null, null, null);
            RequisitionDetail rd277 = new RequisitionDetail(64, "P043", 2880, 2880, 2880, null, null, null, null);
            RequisitionDetail rd278 = new RequisitionDetail(65, "P043", 3160, 3160, 3160, null, null, null, null);
            RequisitionDetail rd279 = new RequisitionDetail(66, "P043", 3100, 3100, 3100, null, null, null, null);
            RequisitionDetail rd280 = new RequisitionDetail(67, "P043", 2940, 2940, 2940, null, null, null, null);
            RequisitionDetail rd281 = new RequisitionDetail(68, "P043", 780, 780, 780, null, null, null, null);
            RequisitionDetail rd282 = new RequisitionDetail(69, "P043", 800, 800, 800, null, null, null, null);
            RequisitionDetail rd283 = new RequisitionDetail(70, "P043", 5880, 5880, 5880, null, null, null, null);
            RequisitionDetail rd284 = new RequisitionDetail(71, "P043", 3240, 3240, 3240, null, null, null, null);
            RequisitionDetail rd285 = new RequisitionDetail(72, "P043", 2900, 2900, 2900, null, null, null, null);
            RequisitionDetail rd286 = new RequisitionDetail(73, "P043", 2600, 2600, 2600, null, null, null, null);
            RequisitionDetail rd287 = new RequisitionDetail(74, "P043", 1380, 1380, 1380, null, null, null, null);
            RequisitionDetail rd288 = new RequisitionDetail(75, "P043", 5740, 5740, 5740, null, null, null, null);
            RequisitionDetail rd289 = new RequisitionDetail(76, "P043", 3160, 3160, 3160, null, null, null, null);
            RequisitionDetail rd290 = new RequisitionDetail(77, "P043", 3440, 3440, 3440, null, null, null, null);
            RequisitionDetail rd291 = new RequisitionDetail(78, "P043", 3380, 3380, 3380, null, null, null, null);
            RequisitionDetail rd292 = new RequisitionDetail(79, "P043", 3220, 3220, 3220, null, null, null, null);
            RequisitionDetail rd293 = new RequisitionDetail(80, "P043", 1060, 1060, 1060, null, null, null, null);
            RequisitionDetail rd294 = new RequisitionDetail(81, "P043", 1080, 1080, 1080, null, null, null, null);
            RequisitionDetail rd295 = new RequisitionDetail(82, "P043", 6160, 6160, 6160, null, null, null, null);
            RequisitionDetail rd296 = new RequisitionDetail(83, "P043", 3520, 3520, 3520, null, null, null, null);
            RequisitionDetail rd297 = new RequisitionDetail(84, "P043", 3180, 3180, 3180, null, null, null, null);
            RequisitionDetail rd298 = new RequisitionDetail(85, "P043", 2880, 2880, 2880, null, null, null, null);
            RequisitionDetail rd299 = new RequisitionDetail(86, "P043", 1660, 1660, 1660, null, null, null, null);
            RequisitionDetail rd300 = new RequisitionDetail(87, "P043", 6040, 6040, 6040, null, null, null, null);
            RequisitionDetail rd301 = new RequisitionDetail(88, "P043", 3460, 3460, 3460, null, null, null, null);
            RequisitionDetail rd302 = new RequisitionDetail(89, "P043", 3740, 3740, 3740, null, null, null, null);
            RequisitionDetail rd303 = new RequisitionDetail(90, "P043", 3680, 3680, 3680, null, null, null, null);
            RequisitionDetail rd304 = new RequisitionDetail(91, "P043", 3520, 3520, 3520, null, null, null, null);
            RequisitionDetail rd305 = new RequisitionDetail(92, "P043", 1360, 1360, 1360, null, null, null, null);
            RequisitionDetail rd306 = new RequisitionDetail(93, "P043", 1380, 1380, 1380, null, null, null, null);
            RequisitionDetail rd307 = new RequisitionDetail(94, "P043", 6460, 6460, 6460, null, null, null, null);
            RequisitionDetail rd308 = new RequisitionDetail(95, "P043", 3820, 3820, 3820, null, null, null, null);
            RequisitionDetail rd309 = new RequisitionDetail(96, "P043", 3480, 3480, 3480, null, null, null, null);
            RequisitionDetail rd310 = new RequisitionDetail(97, "P043", 3180, 3180, 3180, null, null, null, null);
            RequisitionDetail rd311 = new RequisitionDetail(98, "P043", 1960, 1960, 1960, null, null, null, null);
            RequisitionDetail rd312 = new RequisitionDetail(99, "P043", 6180, 6180, 6180, null, null, null, null);
            RequisitionDetail rd313 = new RequisitionDetail(100, "P043", 3600, 3600, 3600, null, null, null, null);
            RequisitionDetail rd314 = new RequisitionDetail(101, "P043", 3880, 3880, 3880, null, null, null, null);
            RequisitionDetail rd315 = new RequisitionDetail(102, "P043", 3820, 3820, 3820, null, null, null, null);
            RequisitionDetail rd316 = new RequisitionDetail(103, "P043", 3660, 3660, 3660, null, null, null, null);
            RequisitionDetail rd317 = new RequisitionDetail(104, "P043", 1500, 1500, 1500, null, null, null, null);
            RequisitionDetail rd318 = new RequisitionDetail(105, "P043", 1520, 1520, 1520, null, null, null, null);
            RequisitionDetail rd319 = new RequisitionDetail(106, "P043", 6600, 6600, 6600, null, null, null, null);
            RequisitionDetail rd320 = new RequisitionDetail(107, "P043", 3960, 3960, 3960, null, null, null, null);
            RequisitionDetail rd321 = new RequisitionDetail(108, "P043", 3620, 3620, 3620, null, null, null, null);
            RequisitionDetail rd322 = new RequisitionDetail(109, "P043", 3320, 3320, 3320, null, null, null, null);
            RequisitionDetail rd323 = new RequisitionDetail(110, "P043", 2100, 2100, 2100, null, null, null, null);
            dbcontext.Add(rd36);
            dbcontext.SaveChanges();
            dbcontext.Add(rd37);
            dbcontext.SaveChanges();
            dbcontext.Add(rd38);
            dbcontext.SaveChanges();
            dbcontext.Add(rd39);
            dbcontext.SaveChanges();
            dbcontext.Add(rd40);
            dbcontext.SaveChanges();
            dbcontext.Add(rd41);
            dbcontext.SaveChanges();
            dbcontext.Add(rd42);
            dbcontext.SaveChanges();
            dbcontext.Add(rd43);
            dbcontext.SaveChanges();
            dbcontext.Add(rd44);
            dbcontext.SaveChanges();
            dbcontext.Add(rd45);
            dbcontext.SaveChanges();
            dbcontext.Add(rd46);
            dbcontext.SaveChanges();
            dbcontext.Add(rd47);
            dbcontext.SaveChanges();
            dbcontext.Add(rd48);
            dbcontext.SaveChanges();
            dbcontext.Add(rd49);
            dbcontext.SaveChanges();
            dbcontext.Add(rd50);
            dbcontext.SaveChanges();
            dbcontext.Add(rd51);
            dbcontext.SaveChanges();
            dbcontext.Add(rd52);
            dbcontext.SaveChanges();
            dbcontext.Add(rd53);
            dbcontext.SaveChanges();
            dbcontext.Add(rd54);
            dbcontext.SaveChanges();
            dbcontext.Add(rd55);
            dbcontext.SaveChanges();
            dbcontext.Add(rd56);
            dbcontext.SaveChanges();
            dbcontext.Add(rd57);
            dbcontext.SaveChanges();
            dbcontext.Add(rd58);
            dbcontext.SaveChanges();
            dbcontext.Add(rd59);
            dbcontext.SaveChanges();
            dbcontext.Add(rd60);
            dbcontext.SaveChanges();
            dbcontext.Add(rd61);
            dbcontext.SaveChanges();
            dbcontext.Add(rd62);
            dbcontext.SaveChanges();
            dbcontext.Add(rd63);
            dbcontext.SaveChanges();
            dbcontext.Add(rd64);
            dbcontext.SaveChanges();
            dbcontext.Add(rd65);
            dbcontext.SaveChanges();
            dbcontext.Add(rd66);
            dbcontext.SaveChanges();
            dbcontext.Add(rd67);
            dbcontext.SaveChanges();
            dbcontext.Add(rd68);
            dbcontext.SaveChanges();
            dbcontext.Add(rd69);
            dbcontext.SaveChanges();
            dbcontext.Add(rd70);
            dbcontext.SaveChanges();
            dbcontext.Add(rd71);
            dbcontext.SaveChanges();
            dbcontext.Add(rd72);
            dbcontext.SaveChanges();
            dbcontext.Add(rd73);
            dbcontext.SaveChanges();
            dbcontext.Add(rd74);
            dbcontext.SaveChanges();
            dbcontext.Add(rd75);
            dbcontext.SaveChanges();
            dbcontext.Add(rd76);
            dbcontext.SaveChanges();
            dbcontext.Add(rd77);
            dbcontext.SaveChanges();
            dbcontext.Add(rd78);
            dbcontext.SaveChanges();
            dbcontext.Add(rd79);
            dbcontext.SaveChanges();
            dbcontext.Add(rd80);
            dbcontext.SaveChanges();
            dbcontext.Add(rd81);
            dbcontext.SaveChanges();
            dbcontext.Add(rd82);
            dbcontext.SaveChanges();
            dbcontext.Add(rd83);
            dbcontext.SaveChanges();
            dbcontext.Add(rd84);
            dbcontext.SaveChanges();
            dbcontext.Add(rd85);
            dbcontext.SaveChanges();
            dbcontext.Add(rd86);
            dbcontext.SaveChanges();
            dbcontext.Add(rd87);
            dbcontext.SaveChanges();
            dbcontext.Add(rd88);
            dbcontext.SaveChanges();
            dbcontext.Add(rd89);
            dbcontext.SaveChanges();
            dbcontext.Add(rd90);
            dbcontext.SaveChanges();
            dbcontext.Add(rd91);
            dbcontext.SaveChanges();
            dbcontext.Add(rd92);
            dbcontext.SaveChanges();
            dbcontext.Add(rd93);
            dbcontext.SaveChanges();
            dbcontext.Add(rd94);
            dbcontext.SaveChanges();
            dbcontext.Add(rd95);
            dbcontext.SaveChanges();
            dbcontext.Add(rd96);
            dbcontext.SaveChanges();
            dbcontext.Add(rd97);
            dbcontext.SaveChanges();
            dbcontext.Add(rd98);
            dbcontext.SaveChanges();
            dbcontext.Add(rd99);
            dbcontext.SaveChanges();
            dbcontext.Add(rd100);
            dbcontext.SaveChanges();
            dbcontext.Add(rd101);
            dbcontext.SaveChanges();
            dbcontext.Add(rd102);
            dbcontext.SaveChanges();
            dbcontext.Add(rd103);
            dbcontext.SaveChanges();
            dbcontext.Add(rd104);
            dbcontext.SaveChanges();
            dbcontext.Add(rd105);
            dbcontext.SaveChanges();
            dbcontext.Add(rd106);
            dbcontext.SaveChanges();
            dbcontext.Add(rd107);
            dbcontext.SaveChanges();
            dbcontext.Add(rd108);
            dbcontext.SaveChanges();
            dbcontext.Add(rd109);
            dbcontext.SaveChanges();
            dbcontext.Add(rd110);
            dbcontext.SaveChanges();
            dbcontext.Add(rd111);
            dbcontext.SaveChanges();
            dbcontext.Add(rd112);
            dbcontext.SaveChanges();
            dbcontext.Add(rd113);
            dbcontext.SaveChanges();
            dbcontext.Add(rd114);
            dbcontext.SaveChanges();
            dbcontext.Add(rd115);
            dbcontext.SaveChanges();
            dbcontext.Add(rd116);
            dbcontext.SaveChanges();
            dbcontext.Add(rd117);
            dbcontext.SaveChanges();
            dbcontext.Add(rd118);
            dbcontext.SaveChanges();
            dbcontext.Add(rd119);
            dbcontext.SaveChanges();
            dbcontext.Add(rd120);
            dbcontext.SaveChanges();
            dbcontext.Add(rd121);
            dbcontext.SaveChanges();
            dbcontext.Add(rd122);
            dbcontext.SaveChanges();
            dbcontext.Add(rd123);
            dbcontext.SaveChanges();
            dbcontext.Add(rd124);
            dbcontext.SaveChanges();
            dbcontext.Add(rd125);
            dbcontext.SaveChanges();
            dbcontext.Add(rd126);
            dbcontext.SaveChanges();
            dbcontext.Add(rd127);
            dbcontext.SaveChanges();
            dbcontext.Add(rd128);
            dbcontext.SaveChanges();
            dbcontext.Add(rd129);
            dbcontext.SaveChanges();
            dbcontext.Add(rd130);
            dbcontext.SaveChanges();
            dbcontext.Add(rd131);
            dbcontext.SaveChanges();
            dbcontext.Add(rd132);
            dbcontext.SaveChanges();
            dbcontext.Add(rd133);
            dbcontext.SaveChanges();
            dbcontext.Add(rd134);
            dbcontext.SaveChanges();
            dbcontext.Add(rd135);
            dbcontext.SaveChanges();
            dbcontext.Add(rd136);
            dbcontext.SaveChanges();
            dbcontext.Add(rd137);
            dbcontext.SaveChanges();
            dbcontext.Add(rd138);
            dbcontext.SaveChanges();
            dbcontext.Add(rd139);
            dbcontext.SaveChanges();
            dbcontext.Add(rd140);
            dbcontext.SaveChanges();
            dbcontext.Add(rd141);
            dbcontext.SaveChanges();
            dbcontext.Add(rd142);
            dbcontext.SaveChanges();
            dbcontext.Add(rd143);
            dbcontext.SaveChanges();
            dbcontext.Add(rd144);
            dbcontext.SaveChanges();
            dbcontext.Add(rd145);
            dbcontext.SaveChanges();
            dbcontext.Add(rd146);
            dbcontext.SaveChanges();
            dbcontext.Add(rd147);
            dbcontext.SaveChanges();
            dbcontext.Add(rd148);
            dbcontext.SaveChanges();
            dbcontext.Add(rd149);
            dbcontext.SaveChanges();
            dbcontext.Add(rd150);
            dbcontext.SaveChanges();
            dbcontext.Add(rd151);
            dbcontext.SaveChanges();
            dbcontext.Add(rd152);
            dbcontext.SaveChanges();
            dbcontext.Add(rd153);
            dbcontext.SaveChanges();
            dbcontext.Add(rd154);
            dbcontext.SaveChanges();
            dbcontext.Add(rd155);
            dbcontext.SaveChanges();
            dbcontext.Add(rd156);
            dbcontext.SaveChanges();
            dbcontext.Add(rd157);
            dbcontext.SaveChanges();
            dbcontext.Add(rd158);
            dbcontext.SaveChanges();
            dbcontext.Add(rd159);
            dbcontext.SaveChanges();
            dbcontext.Add(rd160);
            dbcontext.SaveChanges();
            dbcontext.Add(rd161);
            dbcontext.SaveChanges();
            dbcontext.Add(rd162);
            dbcontext.SaveChanges();
            dbcontext.Add(rd163);
            dbcontext.SaveChanges();
            dbcontext.Add(rd164);
            dbcontext.SaveChanges();
            dbcontext.Add(rd165);
            dbcontext.SaveChanges();
            dbcontext.Add(rd166);
            dbcontext.SaveChanges();
            dbcontext.Add(rd167);
            dbcontext.SaveChanges();
            dbcontext.Add(rd168);
            dbcontext.SaveChanges();
            dbcontext.Add(rd169);
            dbcontext.SaveChanges();
            dbcontext.Add(rd170);
            dbcontext.SaveChanges();
            dbcontext.Add(rd171);
            dbcontext.SaveChanges();
            dbcontext.Add(rd172);
            dbcontext.SaveChanges();
            dbcontext.Add(rd173);
            dbcontext.SaveChanges();
            dbcontext.Add(rd174);
            dbcontext.SaveChanges();
            dbcontext.Add(rd175);
            dbcontext.SaveChanges();
            dbcontext.Add(rd176);
            dbcontext.SaveChanges();
            dbcontext.Add(rd177);
            dbcontext.SaveChanges();
            dbcontext.Add(rd178);
            dbcontext.SaveChanges();
            dbcontext.Add(rd179);
            dbcontext.SaveChanges();
            dbcontext.Add(rd180);
            dbcontext.SaveChanges();
            dbcontext.Add(rd181);
            dbcontext.SaveChanges();
            dbcontext.Add(rd182);
            dbcontext.SaveChanges();
            dbcontext.Add(rd183);
            dbcontext.SaveChanges();
            dbcontext.Add(rd184);
            dbcontext.SaveChanges();
            dbcontext.Add(rd185);
            dbcontext.SaveChanges();
            dbcontext.Add(rd186);
            dbcontext.SaveChanges();
            dbcontext.Add(rd187);
            dbcontext.SaveChanges();
            dbcontext.Add(rd188);
            dbcontext.SaveChanges();
            dbcontext.Add(rd189);
            dbcontext.SaveChanges();
            dbcontext.Add(rd190);
            dbcontext.SaveChanges();
            dbcontext.Add(rd191);
            dbcontext.SaveChanges();
            dbcontext.Add(rd192);
            dbcontext.SaveChanges();
            dbcontext.Add(rd193);
            dbcontext.SaveChanges();
            dbcontext.Add(rd194);
            dbcontext.SaveChanges();
            dbcontext.Add(rd195);
            dbcontext.SaveChanges();
            dbcontext.Add(rd196);
            dbcontext.SaveChanges();
            dbcontext.Add(rd197);
            dbcontext.SaveChanges();
            dbcontext.Add(rd198);
            dbcontext.SaveChanges();
            dbcontext.Add(rd199);
            dbcontext.SaveChanges();
            dbcontext.Add(rd200);
            dbcontext.SaveChanges();
            dbcontext.Add(rd201);
            dbcontext.SaveChanges();
            dbcontext.Add(rd202);
            dbcontext.SaveChanges();
            dbcontext.Add(rd203);
            dbcontext.SaveChanges();
            dbcontext.Add(rd204);
            dbcontext.SaveChanges();
            dbcontext.Add(rd205);
            dbcontext.SaveChanges();
            dbcontext.Add(rd206);
            dbcontext.SaveChanges();
            dbcontext.Add(rd207);
            dbcontext.SaveChanges();
            dbcontext.Add(rd208);
            dbcontext.SaveChanges();
            dbcontext.Add(rd209);
            dbcontext.SaveChanges();
            dbcontext.Add(rd210);
            dbcontext.SaveChanges();
            dbcontext.Add(rd211);
            dbcontext.SaveChanges();
            dbcontext.Add(rd212);
            dbcontext.SaveChanges();
            dbcontext.Add(rd213);
            dbcontext.SaveChanges();
            dbcontext.Add(rd214);
            dbcontext.SaveChanges();
            dbcontext.Add(rd215);
            dbcontext.SaveChanges();
            dbcontext.Add(rd216);
            dbcontext.SaveChanges();
            dbcontext.Add(rd217);
            dbcontext.SaveChanges();
            dbcontext.Add(rd218);
            dbcontext.SaveChanges();
            dbcontext.Add(rd219);
            dbcontext.SaveChanges();
            dbcontext.Add(rd220);
            dbcontext.SaveChanges();
            dbcontext.Add(rd221);
            dbcontext.SaveChanges();
            dbcontext.Add(rd222);
            dbcontext.SaveChanges();
            dbcontext.Add(rd223);
            dbcontext.SaveChanges();
            dbcontext.Add(rd224);
            dbcontext.SaveChanges();
            dbcontext.Add(rd225);
            dbcontext.SaveChanges();
            dbcontext.Add(rd226);
            dbcontext.SaveChanges();
            dbcontext.Add(rd227);
            dbcontext.SaveChanges();
            dbcontext.Add(rd228);
            dbcontext.SaveChanges();
            dbcontext.Add(rd229);
            dbcontext.SaveChanges();
            dbcontext.Add(rd230);
            dbcontext.SaveChanges();
            dbcontext.Add(rd231);
            dbcontext.SaveChanges();
            dbcontext.Add(rd232);
            dbcontext.SaveChanges();
            dbcontext.Add(rd233);
            dbcontext.SaveChanges();
            dbcontext.Add(rd234);
            dbcontext.SaveChanges();
            dbcontext.Add(rd235);
            dbcontext.SaveChanges();
            dbcontext.Add(rd236);
            dbcontext.SaveChanges();
            dbcontext.Add(rd237);
            dbcontext.SaveChanges();
            dbcontext.Add(rd238);
            dbcontext.SaveChanges();
            dbcontext.Add(rd239);
            dbcontext.SaveChanges();
            dbcontext.Add(rd240);
            dbcontext.SaveChanges();
            dbcontext.Add(rd241);
            dbcontext.SaveChanges();
            dbcontext.Add(rd242);
            dbcontext.SaveChanges();
            dbcontext.Add(rd243);
            dbcontext.SaveChanges();
            dbcontext.Add(rd244);
            dbcontext.SaveChanges();
            dbcontext.Add(rd245);
            dbcontext.SaveChanges();
            dbcontext.Add(rd246);
            dbcontext.SaveChanges();
            dbcontext.Add(rd247);
            dbcontext.SaveChanges();
            dbcontext.Add(rd248);
            dbcontext.SaveChanges();
            dbcontext.Add(rd249);
            dbcontext.SaveChanges();
            dbcontext.Add(rd250);
            dbcontext.SaveChanges();
            dbcontext.Add(rd251);
            dbcontext.SaveChanges();
            dbcontext.Add(rd252);
            dbcontext.SaveChanges();
            dbcontext.Add(rd253);
            dbcontext.SaveChanges();
            dbcontext.Add(rd254);
            dbcontext.SaveChanges();
            dbcontext.Add(rd255);
            dbcontext.SaveChanges();
            dbcontext.Add(rd256);
            dbcontext.SaveChanges();
            dbcontext.Add(rd257);
            dbcontext.SaveChanges();
            dbcontext.Add(rd258);
            dbcontext.SaveChanges();
            dbcontext.Add(rd259);
            dbcontext.SaveChanges();
            dbcontext.Add(rd260);
            dbcontext.SaveChanges();
            dbcontext.Add(rd261);
            dbcontext.SaveChanges();
            dbcontext.Add(rd262);
            dbcontext.SaveChanges();
            dbcontext.Add(rd263);
            dbcontext.SaveChanges();
            dbcontext.Add(rd264);
            dbcontext.SaveChanges();
            dbcontext.Add(rd265);
            dbcontext.SaveChanges();
            dbcontext.Add(rd266);
            dbcontext.SaveChanges();
            dbcontext.Add(rd267);
            dbcontext.SaveChanges();
            dbcontext.Add(rd268);
            dbcontext.SaveChanges();
            dbcontext.Add(rd269);
            dbcontext.SaveChanges();
            dbcontext.Add(rd270);
            dbcontext.SaveChanges();
            dbcontext.Add(rd271);
            dbcontext.SaveChanges();
            dbcontext.Add(rd272);
            dbcontext.SaveChanges();
            dbcontext.Add(rd273);
            dbcontext.SaveChanges();
            dbcontext.Add(rd274);
            dbcontext.SaveChanges();
            dbcontext.Add(rd275);
            dbcontext.SaveChanges();
            dbcontext.Add(rd276);
            dbcontext.SaveChanges();
            dbcontext.Add(rd277);
            dbcontext.SaveChanges();
            dbcontext.Add(rd278);
            dbcontext.SaveChanges();
            dbcontext.Add(rd279);
            dbcontext.SaveChanges();
            dbcontext.Add(rd280);
            dbcontext.SaveChanges();
            dbcontext.Add(rd281);
            dbcontext.SaveChanges();
            dbcontext.Add(rd282);
            dbcontext.SaveChanges();
            dbcontext.Add(rd283);
            dbcontext.SaveChanges();
            dbcontext.Add(rd284);
            dbcontext.SaveChanges();
            dbcontext.Add(rd285);
            dbcontext.SaveChanges();
            dbcontext.Add(rd286);
            dbcontext.SaveChanges();
            dbcontext.Add(rd287);
            dbcontext.SaveChanges();
            dbcontext.Add(rd288);
            dbcontext.SaveChanges();
            dbcontext.Add(rd289);
            dbcontext.SaveChanges();
            dbcontext.Add(rd290);
            dbcontext.SaveChanges();
            dbcontext.Add(rd291);
            dbcontext.SaveChanges();
            dbcontext.Add(rd292);
            dbcontext.SaveChanges();
            dbcontext.Add(rd293);
            dbcontext.SaveChanges();
            dbcontext.Add(rd294);
            dbcontext.SaveChanges();
            dbcontext.Add(rd295);
            dbcontext.SaveChanges();
            dbcontext.Add(rd296);
            dbcontext.SaveChanges();
            dbcontext.Add(rd297);
            dbcontext.SaveChanges();
            dbcontext.Add(rd298);
            dbcontext.SaveChanges();
            dbcontext.Add(rd299);
            dbcontext.SaveChanges();
            dbcontext.Add(rd300);
            dbcontext.SaveChanges();
            dbcontext.Add(rd301);
            dbcontext.SaveChanges();
            dbcontext.Add(rd302);
            dbcontext.SaveChanges();
            dbcontext.Add(rd303);
            dbcontext.SaveChanges();
            dbcontext.Add(rd304);
            dbcontext.SaveChanges();
            dbcontext.Add(rd305);
            dbcontext.SaveChanges();
            dbcontext.Add(rd306);
            dbcontext.SaveChanges();
            dbcontext.Add(rd307);
            dbcontext.SaveChanges();
            dbcontext.Add(rd308);
            dbcontext.SaveChanges();
            dbcontext.Add(rd309);
            dbcontext.SaveChanges();
            dbcontext.Add(rd310);
            dbcontext.SaveChanges();
            dbcontext.Add(rd311);
            dbcontext.SaveChanges();
            dbcontext.Add(rd312);
            dbcontext.SaveChanges();
            dbcontext.Add(rd313);
            dbcontext.SaveChanges();
            dbcontext.Add(rd314);
            dbcontext.SaveChanges();
            dbcontext.Add(rd315);
            dbcontext.SaveChanges();
            dbcontext.Add(rd316);
            dbcontext.SaveChanges();
            dbcontext.Add(rd317);
            dbcontext.SaveChanges();
            dbcontext.Add(rd318);
            dbcontext.SaveChanges();
            dbcontext.Add(rd319);
            dbcontext.SaveChanges();
            dbcontext.Add(rd320);
            dbcontext.SaveChanges();
            dbcontext.Add(rd321);
            dbcontext.SaveChanges();
            dbcontext.Add(rd322);
            dbcontext.SaveChanges();
            dbcontext.Add(rd323);
            dbcontext.SaveChanges();
            //End of RequisitionDetail CSV Seeder

            //seed adjustment voucher
            //public AdjustmentVoucher(string Id, int InitiatedClerkId, long InitiatedDate, 
            //int? ApprovedSupId, long? ApprovedSupDate, int? ApprovedMgrId, long? ApprovedMgrDate, string Status)

            //adjustment voucher in June that >250,due to wet exercise book"E032"x100 and spoilt diskettes "D001"x20 ,
            //created on 29/6@9:00am; approved by sup on 29/6@ 3:00pm, and approved by manager on 30/6/@3:00pm
            AdjustmentVoucher adj1 = new AdjustmentVoucher("001_06_2020", 16, 1593421200000, 2, 1593442800000, 3, 1593529200000, Status.AdjVoucherStatus.approved);
            dbcontext.Add(adj1);
            dbcontext.SaveChanges();

            //Adjustment voucher raised on 31/7; due to 2 rusty clips found on 17/7/2020 retrival, approved by sup on 3/8/2020
            AdjustmentVoucher adj2 = new AdjustmentVoucher("001_07_2020", 1, 1596207600000, 2, 1596447000000, Status.AdjVoucherStatus.pendapprov);
            dbcontext.Add(adj2);
            dbcontext.SaveChanges();

            //Adjustment voucher raised on 15/8 approved by sup on 16/8/2020
            AdjustmentVoucher adj3 = new AdjustmentVoucher("001_08_2020", 1, 1597449600000, 2, 1597536000000, Status.AdjVoucherStatus.created);
            dbcontext.Add(adj3);
            dbcontext.SaveChanges();

            //public AdjustmentVoucherDetail(string AdjustmentVoucherId, string ProductId, int QtyAdjusted, double Unitprice, double TotalPrice, string Reason)
            //seed adjustment voucher detail
            //adjustment voucher in June that >250,due to wet paper"E032" x100 and spoilt diskettes "D001"x20, created on 29/6@9:00am; and approved by manager on 30/6/3pm
            //wet paper"E032" x100
            AdjustmentVoucherDetail adjdet1 = new AdjustmentVoucherDetail("001_06_2020", "E032", -100,1.00, 100.00, "100 wet paper due to heavy rain");
            dbcontext.Add(adjdet1);
            dbcontext.SaveChanges();

            AdjustmentVoucherDetail adjdet2 = new AdjustmentVoucherDetail("001_07_2020", "D001", -20,10.00, 200.00, "20 diskettes found spoilt due to heavy rain");
            dbcontext.Add(adjdet2);
            dbcontext.SaveChanges();

            //public AdjustmentVoucherDetail(string AdjustmentVoucherId, string ProductId, int QtyAdjusted, double TotalPrice, string Reason)
            //seed purchase request detail
            AdjustmentVoucherDetail adjdet3 = new AdjustmentVoucherDetail("001_07_2020", "C001", -2, 2.00,4.00, "2 clips in inventory found rusty, spoilt");
            dbcontext.Add(adjdet3);
            dbcontext.SaveChanges();


            AdjustmentVoucherDetail adjdet4 = new AdjustmentVoucherDetail("001_08_2020", "D001", -26, 10, 260.00, "26 diskettes went missing");
            dbcontext.Add(adjdet4);
            dbcontext.SaveChanges();

            AdjustmentVoucherDetail adjdet5 = new AdjustmentVoucherDetail("001_08_2020", "E032", -2, 1.00, 2.00, "Exercise book - water damage");
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
            po1.Status = Status.PurchaseOrderStatus.completed;
            PurchaseOrder po2 = new PurchaseOrder("OMEG", 300.00, 1, 1593617400000, 1594771200000, 2);
            po2.Status = Status.PurchaseOrderStatus.completed;
            // 15/7 / 2020 @ 8:00am Purchase request of Clip "C001"x15, supply by 31/7/2020 @00:00, recieved on 29/7/2020 @ 9:30am(trans13)
            PurchaseOrder po3 = new PurchaseOrder("ALPA", 30.00, 1, 1594800000000, 1596153600000, 2);
            po3.Status = Status.PurchaseOrderStatus.completed;
            PurchaseOrder po4 = new PurchaseOrder("BANE", 100.00, 16, 1595926800000, 1597190400000, 2);
            po4.Status = Status.PurchaseOrderStatus.pending;
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
            PurchaseOrderDetail poDet1 = new PurchaseOrderDetail(1, 1, "E032", 100, 80, 100.00, "DO001", "Only 80 received", Status.PurchaseOrderDetailStatus.received);
            poDet1.ReceivedByClerkId = 1;
            poDet1.ReceivedDate = 1594771200000;
            PurchaseOrderDetail poDet2 = new PurchaseOrderDetail(2, 2, "D001", 30, 30, 300.00, "DO002", null, Status.PurchaseOrderDetailStatus.received);
            poDet2.ReceivedByClerkId = 16;
            poDet2.ReceivedDate = 1594771200000;
            PurchaseOrderDetail poDet3 = new PurchaseOrderDetail(3, 4, "C001", 15, 15, 30.00, "DO003", null, Status.PurchaseOrderDetailStatus.received);
            poDet3.ReceivedByClerkId = 16;
            poDet3.ReceivedDate = 1596153600000;
            PurchaseOrderDetail poDet4 = new PurchaseOrderDetail(4, 5, "P043", 500, 500, 500.00, "DO004", null, Status.PurchaseOrderDetailStatus.received);
            poDet4.ReceivedByClerkId = 1;
            poDet4.ReceivedDate = 1597190400000;
            PurchaseOrderDetail poDet5 = new PurchaseOrderDetail(4, 3, "C001", 15, null, 30.00, null, null, Status.PurchaseOrderDetailStatus.pending);
            dbcontext.Add(poDet1);
            dbcontext.Add(poDet2);
            dbcontext.Add(poDet3);
            dbcontext.Add(poDet4);
            dbcontext.Add(poDet5);
            dbcontext.SaveChanges();




        }
    }
}
