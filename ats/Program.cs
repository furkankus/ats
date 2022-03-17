using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ats
{
    class Program
    {
        static SqlConnection baglanti;
        static SqlCommand komut;
        static SqlDataReader reader;
        static void Main(string[] args)
        {
        giris:
            //Decalre a new XMLDocument object
            XmlDocument doc = new XmlDocument();
            //xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            //create the root element
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);


            //string.Empty makes cleaner code

            XmlElement element1 = doc.CreateElement("Mainbody");
            doc.AppendChild(element1);
            XmlElement element2 = doc.CreateElement("Orders");


            XmlElement element3 = doc.CreateElement("OrdersNo");
            Console.WriteLine("Orders Numarası Giriniz");
            XmlText text1 = doc.CreateTextNode(Console.ReadLine());

            XmlElement element4 = doc.CreateElement("OrderDesc");
            Console.WriteLine("Orders Description Giriniz");
            XmlText text2 = doc.CreateTextNode(Console.ReadLine());

            XmlElement element5 = doc.CreateElement("OrderQuentity"
                );
            Console.WriteLine("Quentity Adeti Giriniz");
            XmlText text3 = doc.CreateTextNode(Console.ReadLine());
            
        kayıt:
            Console.WriteLine("Katdetmek İstediğinize Emin Misiniz ? Y/N");
            string yes = Console.ReadLine();
            



            if (yes.ToUpper() == "Y")
            {

                element1.AppendChild(element2);

                element2.AppendChild(element3);
                element3.AppendChild(text1);

                element2.AppendChild(element4);
                element4.AppendChild(text2);

                element2.AppendChild(element5);
                element5.AppendChild(text3);


                element2.AppendChild(element5);

                
                doc.Save(Directory.GetCurrentDirectory() + $@"//Success//documentsuccess{text1.Data}.xml");

                baglanti = new SqlConnection();
                baglanti.ConnectionString = "Data Source=.;Initial Catalog=ATSMES;Integrated Security=SSPI";
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "INSERT INTO OrderTable (OrderNo,OrderDesc,OrderQuentity) VALUES ('" + text1  + "','" + text2 + "','" + text3 + "')";

                baglanti.Open();
                int sonuc = komut.ExecuteNonQuery();
                baglanti.Close();
                if (sonuc > 0)
                {
                    Console.WriteLine("Eklendi");
                    Listele();
                }
                else
                {
                    Console.WriteLine("Başarısız");
                }

                
                Console.WriteLine("Yeni giriş yapmak istiyor musunuz ? Y/N");
                string evet = Console.ReadLine();
                if (evet.ToUpper() == "Y")
                {
                    goto giris;
                }
                else 
                {
                    Console.WriteLine(@"Yeni kayıt oluşturulmamıştır. Mevcut Kayıtlar aşağıdaki gibidir. ");
                    Listele();
                }
            }
            
            else 
            {
                Console.WriteLine("Yeni Bir kayıt işlemi için her hangi bir tuşa basınız");
                Console.ReadLine();

                element1.AppendChild(element2);

                element2.AppendChild(element3);
                element3.AppendChild(text1);

                element2.AppendChild(element4);
                element4.AppendChild(text2);

                element2.AppendChild(element5);
                element5.AppendChild(text3);


                element2.AppendChild(element5);


                doc.Save(Directory.GetCurrentDirectory() + $"//False//documentfalse{text1.Data}.xml");
                goto giris;

            }

            
            Console.WriteLine("Güncelemek ister misiniz? Y/N");
            string y = Console.ReadLine();
            string n = Console.ReadLine();

            if (y.ToUpper() == "Y")
            {
                Console.WriteLine("Değiştirmek istediğiniz OrderNo giriniz.");
                int OrderNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("OrderDesc giriniz.");
                string OrderDesc = Console.ReadLine();
                Console.WriteLine("OrderQuen giriniz.");
                int OrderQuen = Convert.ToInt32(Console.ReadLine());


                baglanti = new SqlConnection();
                baglanti.ConnectionString = "Data Source=.;Initial Catalog=ATSMES;Integrated Security=SSPI";
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "UPDATE OrderTable SET OrderDesc='" + OrderDesc + "',OrderQuentity='" + OrderQuen + "' Where OrderNo=" + OrderNo;

                //GÜNCELEME YAPMIYOR WHERE TARAFINA BAKILMALI

                baglanti.Open();
                int sonuc2 = komut.ExecuteNonQuery();
                baglanti.Close();
                if (sonuc2 > 0)
                {
                    Console.WriteLine("Güncellendi");
                }
                else
                {
                    Console.WriteLine("Başarısız");
                }
            }
            else
            {
                Console.WriteLine("Teşekkür ederiz.");
                Console.ReadKey();
            }

        }







        public static void Listele()
        {
            int sayac = 0;
            string sinif = Console.ReadLine();
            baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=.;Initial Catalog=ATSMES;Integrated Security=SSPI";
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM OrderTable";
            baglanti.Open();
            reader = komut.ExecuteReader();
            while (reader.Read())
            {
                sayac++;
                Console.WriteLine("Order No:  " + reader[0] + " " +
                                  "Order Desc: " + reader[1] + " " +
                                  "Order Quen: " + reader[2]);

            }
            baglanti.Close();
            Console.WriteLine("Mevcut Kayıt Sayısı:" + sayac + " kayıt");
        }


    }


}

