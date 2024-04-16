namespace ModuleSeven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new("Евгений", "ул.Октябрьская");
            Client client2 = new("Никита", "ул. Текстильщиков");
            Client client3 = new("Марк", "ул. Коммунистическая");

            PickPoint pickPoint1 = new("ул. Лесная");
            Shop shop1 = new("Shop-Shop", "ул. Ленина");
            
            HomeDelivery homeDelivery1 = new(client1.Name, client1.Address);
            PickPointDelivery pickPointDelivery1 = new(client2.Name, pickPoint1.Address);
            ShopDelivery shopDelivery1 = new(shop1.Title, client3.Name, shop1.Address);

            Product product1 = new("Набор ножей", 14999.9);
            Product product2 = new("Клюшка хоккейная", 29990.99);
            Product product3 = new("Рубашка мужская", 5799.50);

            Order<HomeDelivery> order1 = new(homeDelivery1, product1, client1);
            Order<PickPointDelivery> order2 = new(pickPointDelivery1, product2, client2);
            Order<ShopDelivery> order3 = new(shopDelivery1, product3, client3);

            order1.OrderInfo();
            Console.WriteLine();
            order2.OrderInfo();
            Console.WriteLine();
            order3.OrderInfo();
        }

        class Client
        {
            public string Name;
            public string Address;

            public Client(string name, string address)
            {
                Name = name;
                Address = address;
            }
        }

        class Product
        {
            public string Title;
            public double Price;

            public Product(string title, double price)
            {
                Title = title;
                Price = price;
            }
        }

        abstract class Delivery
        {
            public string Address;

            public Delivery(string address)
            {
                Address = address;
            }
        }

        class HomeDelivery : Delivery
        {
            public string ClientName;

            public HomeDelivery(string clientName, string address) : base(address)
            {
                ClientName = clientName;
            }
        }

        class PickPointDelivery : Delivery
        {
            public string ClientName;

            public PickPointDelivery(string clientName, string address) : base(address)
            {
                ClientName = clientName;
            }
        }

        class ShopDelivery : Delivery
        {
            public string Shop;
            public string ClientName;

            public ShopDelivery(string shop, string clientName, string address) : base(address)
            {
                Shop = shop;
                ClientName = clientName;
            }
        }

        class Order<TDelivery> where TDelivery : Delivery
        {
            public TDelivery Delivery;
            public Product Product;
            public Client Client;

            public void OrderInfo()
            {
                if (Delivery is HomeDelivery)
                    Console.WriteLine($"Заказ будет доставлен на дом, {Client.Name}");
                else if (Delivery is PickPointDelivery)
                    Console.WriteLine($"Заказ прибудет в пункт выдачи, {Client.Name}");
                else
                    Console.WriteLine($"Заказ будет доставлен в магазин, {Client.Name}");

                Console.WriteLine($"Адрес: {Delivery.Address}");
                Console.WriteLine($"Товар: {Product.Title}");
                Console.WriteLine($"Стоиомсть: {Product.Price}руб.");
            }

            public Order(TDelivery delivery, Product product, Client client)
            {
                Delivery = delivery;
                Product = product;
                Client = client;
            }
        }

        class Shop
        {
            public string Title;
            public string Address;

            public Shop(string title, string address)
            {
                Title = title;
                Address = address;
            }
        }

        class PickPoint
        {
            public string Address;

            public PickPoint(string address)
            {
                Address = address;
            }
        }
    }
}

