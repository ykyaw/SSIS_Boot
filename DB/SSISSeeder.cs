﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            dbcontext.SaveChanges();


            //seed product
            Product p1 = new Product("C001", "Clips Double 1", 1);
            Product p2 = new Product("C002", "Clips Double 2",1);
            Product p3 = new Product("C003", "Clips Double 3/4",1);
            Product p4 = new Product("C004", "Clips Paper Large", 1);
            Product p5 = new Product("E001", "Envelop Brown (3'x6')",2);
            Product p6 = new Product("E002", "Envelop Brown (3'x6') w/Window",2);
            Product p7 = new Product("E003", "Envelop Brown (6'x7')", 2);
            Product p8 = new Product("E004", "Envelop Brown (6'x7') w/Window", 2);
            Product p9 = new Product("E020", "Eraser (hard)", 3);
            Product p10 = new Product("E021", "Eraser (soft)", 3);
            Product p11 = new Product("E030", "Exercise Book (100pg)", 4);
            Product p12 = new Product("E031", "Exercise Book (120pg)", 4);
            Product p13 = new Product("E032", "Exercise Book A4 Hardcover (100 pg)", 4);
            Product p14 = new Product("E033", "Exercise Book A5 Hardcover (120 pg)", 4);
            Product p15 = new Product("F020", "File Separator", 5);
            Product p16 = new Product("F021", "File-Blue Plain", 5);
            Product p17 = new Product("F022", "File-Blue with Logo", 5);
            Product p18 = new Product("F023", "File-Brown w/o Logo", 5);
            Product p19 = new Product("H011", "Highlighter Blue", 6);//pen
            Product p20 = new Product("H012", "Highlighter Green", 6);
            Product p21 = new Product("H013", "Highlighter Pink", 6);
            Product p22 = new Product("H014", "Highlighter Yellow", 6);
            Product p23 = new Product("H031", "Hole Puncher 2 holes", 7);
            Product p24 = new Product("H032", "Hole Puncher 3 holes", 7);
            Product p25 = new Product("H033", "Hole Puncher Adjustable", 7);
            Product p26 = new Product("P010", "Pad Postit Memo 1'x2'", 8);//8=pad
            Product p27 = new Product("P011", "Pad Postit Memo 1/2'x1'", 8);
            Product p28 = new Product("P012", "Pad Postit Memo 1/2'x2'", 8);
            Product p29 = new Product("P013", "Pad Postit Memo 2'x3'", 8);
            Product p30 = new Product("P043", "Pencil 2b with Eraser End", 6);
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
            dbcontext.SaveChanges();

            //seed collection point
            CollectionPoint c1 = new CollectionPoint("Stationary Store", "9:30AM");
            CollectionPoint c2 = new CollectionPoint("Management School", "11:30AM");
            CollectionPoint c3 = new CollectionPoint("Medical School", "9:30AM");
            CollectionPoint c4 = new CollectionPoint("Engineering School", "11:30AM");
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
            Department d2 = new Department("ENGL", "English Dept", 8742234);
            Department d3 = new Department("CPSC", "Computer Science", 8901235);
            Department d4 = new Department("COMM", "Commerce Dept", 8741284);
            Department d5 = new Department("REGR", "Registrar Dept", 8901266);
            Department d6 = new Department("ZOOL", " Zoology Dept", 8901266);
            dbcontext.Add(d1);
            dbcontext.Add(d2);
            dbcontext.Add(d3);
            dbcontext.Add(d4);
            dbcontext.Add(d5);
            dbcontext.Add(d6);
            dbcontext.SaveChanges();

            //seed employee
            Employee e1 = new Employee("Esther (sc)", "Esther@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "STOR", "sc");
            dbcontext.Add(e1);
          
            dbcontext.SaveChanges();
            Employee e2 = new Employee( "Peter (ss)", "Peter@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "STOR", "ss");
            dbcontext.Add(e2);
            dbcontext.SaveChanges();
            Employee e3 = new Employee( "James (sm)", "James@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "STOR", "sm");
            dbcontext.Add(e3);
            dbcontext.SaveChanges();
            Employee e4 = new Employee("Pamela Kow(de)", "Pamela@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3","ENGL","de");
            dbcontext.Add(e4);
            dbcontext.SaveChanges();
            Employee e5 = new Employee("Ezra Pound (dh)", "Ezra@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "ENGL","dh");
            dbcontext.Add(e5);
            dbcontext.SaveChanges();
            Employee e6 = new Employee( "Wee Kian Fatt", "Pamela@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "CPSC","de");
            dbcontext.Add(e6);
            dbcontext.SaveChanges();
            Employee e7 = new Employee( "soh Kian Wee (dh)", "kw@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "CPSC","de");
            dbcontext.Add(e7);
            dbcontext.SaveChanges();
            Employee e8 = new Employee("Mary Tan(de)", "Mary@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "COMM", "de");
            dbcontext.Add(e8);
            dbcontext.SaveChanges();
            Employee e9 = new Employee("Nasi Lemak (dh)", "Nasilemak@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "COMM", "dh");
            dbcontext.Add(e9);
            dbcontext.SaveChanges();
            Employee e10 = new Employee("Lor Mee", "Lormee@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "REGR", "de");
            dbcontext.Add(e10);
            dbcontext.SaveChanges();
            Employee e11 = new Employee("Carrot Cake (dh)", "Carrotcake@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "REGR", "dh");
            dbcontext.Add(e11);
            dbcontext.SaveChanges();
            Employee e12 = new Employee("Fish Ball(de)", "Fishball@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "ZOOL", "de");
            dbcontext.Add(e12);
            dbcontext.SaveChanges();
            Employee e13 = new Employee("Cheong Fun (dh)", "Cheongfun@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "ZOOL", "dh");
            dbcontext.Add(e13);
            dbcontext.SaveChanges();
            Employee e14 = new Employee("Adeline Yee (de)", "Adeline@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "ENGL", "de");
            dbcontext.Add(e14);
            dbcontext.SaveChanges();
            Employee e15 = new Employee("Nicole Chone(de)", "Nicole@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "CPSC", "de");
            dbcontext.Add(e15);
            Employee e16 = new Employee("Fel (sc)", "Fel@mailinator.com", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", "STOR", "sc");
            dbcontext.Add(e16);
            dbcontext.SaveChanges();

            //set manager to employee
            e4.ManagerId = 5;
            e14.ManagerId = 5;
            e6.ManagerId = 7;
            e15.ManagerId = 15;
            e8.ManagerId = 9;
            e10.ManagerId = 11;
            e12.ManagerId = 13;
            e1.ManagerId = 3;
            e16.ManagerId = 3;
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

            d2.RepId = 4;
            d2.HeadId = 5;
            d3.RepId = 6;
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
            Supplier supplier1 = new Supplier("ALPA", "ALPHA Office Supplies", "Ms Irene Tan", 4619928, 4612238, "Blk 1128, Ang Mo Kio Industrial Park, #02-1108 Ang Mo Kio Street 62,Singapore 622262", "MR -8500440-2");
            Supplier supplier2 = new Supplier("CHEP", "Cheap Stationer", "Mr Soh Kway Koh",3543234, 4742434, "Blk 34, Clementi Road, #07-02 Ban Ban Soh Building, Singapore 110525",null);
            Supplier supplier3 = new Supplier("BANE", "BANES Shop", "Mr Loh Ah Pek", 4781234, 47924344, "Blk 124, Alexandra Road, #03-04 Banes Building, Singapore 550315", "MR-8200420-2");
            Supplier supplier4 = new Supplier("OMEG", "OMEGA Stationery Supplier", "Mr Ronnie Ho", 767233,7671234, "Blk 11, Hillview Avenue, #03-04 , Singapore 679036", "MR-8555330-1");
            dbcontext.Add(supplier1);
            dbcontext.Add(supplier2);
            dbcontext.Add(supplier3);
            dbcontext.Add(supplier4);
            dbcontext.SaveChanges();


            //seed tender quotation
            //public TenderQuotation(string SupplierId, int Year, string ProductId, string PricePerUom,int? Rank)
            TenderQuotation tq1 = new TenderQuotation("BANE", 2020, "P043","Dozen",1); //Bane-2020-pencial with eraser head, 1
            TenderQuotation tq2 = new TenderQuotation("ALPA", 2020, "C001", "Dozen", 1);//ALPA-2020-Clip-1
            TenderQuotation tq3 = new TenderQuotation("AlPA", 2020, "P043", "Dozen", 2);
            TenderQuotation tq4 = new TenderQuotation("BANE", 2020, "C001", "Dozen", 2);
            TenderQuotation tq5 = new TenderQuotation("CHEP", 2020, "C001", "Dozen", 3);
            TenderQuotation tq6 = new TenderQuotation("CHEP", 2020, "P043", "Dozen", 3);
            TenderQuotation tq7 = new TenderQuotation("OMEG", 2020, "C001", "Dozen", null);
            TenderQuotation tq8 = new TenderQuotation("OMEG", 2020, "P043", "Dozen", null);

            dbcontext.Add(tq1);
            dbcontext.Add(tq2);
            dbcontext.Add(tq3);
            dbcontext.Add(tq4);
            dbcontext.Add(tq5);
            dbcontext.Add(tq6);
            dbcontext.Add(tq7);
            dbcontext.Add(tq8);
            dbcontext.SaveChanges();
            //seed transaction
            //public Transaction(string ProductId, DateTime Date, string Description, int Qty, int Balance, int UpdatedByEmpId, string? RefCode)
            Transaction trans1 = new Transaction("P043", 1596441600, "supply from supplier Bane", +500, 550, 1, null);//3/8 / 2020 @ 8:00am(UTC)
            Transaction trans2 = new Transaction("P043", 1596443400, "supply to English Departmen", -20, 530, 1, null); //3/8/2020 @ 8:300am (UTC)
            Transaction trans3 = new Transaction("C001", 1596443400, "stock adjustment 001/008/2020", -2, 182, 1, null); //3/8/2020 @ 8:300am (UTC)


            Transaction trans4 = new Transaction("P043", 1597060800, "Supply to Computing Department", -30, 504, 15, null); //10/8/2020 @ 12:00pm (UTC)
            Transaction trans5 = new Transaction("P043", 1597060800, "Supply to English Department", -50, 454, 15, null);//10/8/2020 @ 12:00pm (UTC)
            Transaction trans6 = new Transaction("C001", 1597060800, "Supply to Computing Department", -10, 8, 1, null); //10/8/2020 @ 12:00pm (UTC)
            Transaction trans7 = new Transaction("C001", 1597060800, "supply to English Department", -8, 0, 15, null);//10/8/2020 @ 12:00pm (UTC)



            Transaction trans8 = new Transaction("C001", 1594724400, "supply from ALPA", 50, 75, 1, null); //14/7/2020 @ 11:00am (UTC)
            Transaction trans9 = new Transaction("C001", 1595237400, "Supply to Computing Department", -10, 65, 1, null); //20/7/2020@9:30am
            Transaction trans10 = new Transaction("C001", 1595237400, "supply to English Department",-50,15, 15, null);//20/7/2020 @ 9:30am (UTC)
            Transaction trans11 = new Transaction("C001", 1595926800, "Supply from ALPA", 15, 18, 15, null);//29/7/2020 @ 9:30am (UTC)

            dbcontext.Add(trans1);
            dbcontext.Add(trans2);
            dbcontext.Add(trans3);
            dbcontext.Add(trans4);
            dbcontext.Add(trans5);
            dbcontext.Add(trans6);
            dbcontext.Add(trans7);
            dbcontext.Add(trans8);
            dbcontext.Add(trans9);
            dbcontext.Add(trans10);
            dbcontext.Add(trans11);
            dbcontext.SaveChanges();

            //seed retrieval(Fri)


            //3/8/2020 


            //seed requsition
            //public Requisition(string DepartmentId, int ReqByEmpId, int ApprovedById, int ProcessedByClerkId)
            Requisition r1 = new Requisition("ENGL", 4, 5, 1);
            r1.CreatedDate = 1594735200;//14/7/2020 @ 2:00pm (UTC)
            r1.Status = "Rejected";
            r1.Remarks = "qty is too irrelavant";
            dbcontext.Add(r1);
            Requisition r2 = new Requisition("CPSC", 6, 7, 1);
            r2.CreatedDate = 1597060800;//10/8/2020 @ 12:00pm (UTC)
            r2.Status = "Confirmed";
            dbcontext.Add(r2);
            dbcontext.SaveChanges();
            //public Requisition(string DepartmentId, int ReqByEmpId, int ApprovedById, string? Remarks,int ProcessedByClerkId, long CreatedDate, string Status,
            //int? CollectionPointId, long? CollectionDate, int? ReceivedByRepId, long? ReceivedDate, int? AckByClerkId, long? AckDate)

            //requisition on 14/7/2020 @ 2:00pm (UTC),dilivered &received on 20/7 @9:30am, 
            Requisition r3 = new Requisition("CPSC", 15, 7, null, 1, 1597060800, "completed",
                                               1, 1595237400,
                                               4, 1595237400, 1, 1595237400);

            Requisition r4 = new Requisition("ENGL", 4, 5, null, 1, 1597060800, "completed",
                                               1, 1595237400,
                                               4, 1595237400, 1, 1595237400);

            //create date- Wednesday, 29-Jul-20 15:00:00 UTC ;receive-03/8/2020 @ 9:30am (UTC);acknowldge-03/8/2020 @ 9:30am
            Requisition r5 = new Requisition("ENGL", 14, 5, null,1, 1596034800,"completed",
                                               1,1596447000,
                                               4, 1596447000,1, 1596447000);

            //created-05 /8/ 2020 09:00:00 (UTC); collection-date-10/8/2020 @930am; received-10/8/2020 @11/:00am; confirmed -10/8/2020@12:00pm
            Requisition r6 = new Requisition("ENGL", 4, 5, null,1, 1596618000, "completed",
                                               1, 1597060800,
                                               4, 1597059000, 1, 1597060800);
            Requisition r7 = new Requisition("CPSC", 6, 7,null, 16, 1596618000, "completed",
                                               1, 1597060800,
                                               4, 1597059000, 1, 1597060800);//created-05 /8/ 2020 09:00:00 (UTC); collection-date-10/8/2020 @930am; received-10/8/2020 @11/:00am; confirmed -10/8/2020@12:00pm

            dbcontext.Add(r3);
            dbcontext.Add(r4);
            dbcontext.Add(r5);
            dbcontext.Add(r6);
            dbcontext.Add(r7);
            dbcontext.SaveChanges();




            //seed requsition detail
            //public RequisitionDetail(int RequisitionId, string ProductId, int QtyNeeded, int? QtyDisbursed, int? QtyReceived,
        //string? DisburseRemark, string? RepRemark, string? ClerkRemark, int? RetrievalId)
            RequisitionDetail rd1 = new RequisitionDetail(1, "C001",500);
            dbcontext.Add(rd1);
            RequisitionDetail rd2 = new RequisitionDetail(2, "C001",15);
            dbcontext.Add(rd2);
            RequisitionDetail rd3 = new RequisitionDetail(5, "C001", 10, 10, 10, null, null, null, null);//left retrival list
            dbcontext.Add(rd3);
            RequisitionDetail rd4 = new RequisitionDetail(5, "C001", 50, 50, 50, null, null, null, null);//left retrival list
            dbcontext.Add(rd4);
            RequisitionDetail rd5 = new RequisitionDetail(5, "P043",20,20,20,null,null,null,null);//left retrival list
            dbcontext.Add(rd5);
            RequisitionDetail rd6 = new RequisitionDetail(6, "P043",50,50,50, null, null, null, null);
            dbcontext.Add(rd6);
            RequisitionDetail rd7 = new RequisitionDetail(6, "C001",10,8,8,"only 8 left","noted",null,null);
            dbcontext.Add(rd7);
            RequisitionDetail rd8 = new RequisitionDetail(7, "P043",30,30,28, null, "2 spoilt", "confirmed", null); //sub need to raise 2 in voucher
            dbcontext.Add(rd8);
            RequisitionDetail rd9 = new RequisitionDetail(7, "C001",10,10,10, null, null, null, null);
            dbcontext.Add(rd9);
            dbcontext.SaveChanges();

            //seed adjustment voucher

            //seed adjustment voucher detail

            //seed purchase request detail

            //seed purchase order

            //seed purchase order detail

        }
        

    }
}
