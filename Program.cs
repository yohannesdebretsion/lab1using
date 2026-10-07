using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        //Product test = new Product("CocaCola is ");
        //Console.WriteLine(test.Name);//this one calls get proporty
        // Order Orderedproduct = new Order(test);
        List<Order> productorder = new List<Order>();
        //Console.WriteLine(Orderedproduct.OrderProduct.Name);
        // Console.WriteLine(Orderedproduct.State);
        /*// WarehouseRobot WR=new WarehouseRobot("order");//this class is an abstract class that cannot intiated
        PackingRobot RobotPacking = new PackingRobot("cocacola is");
        Console.WriteLine(RobotPacking.Name);
        RobotPacking.ProcessOrder(Orderedproduct);
        Console.WriteLine(Orderedproduct.State);
        //for dispatching
        DispatchRobot RobotDispatching = new DispatchRobot("cocacola iis");
        Console.WriteLine(RobotDispatching.Name);
        RobotDispatching.ProcessOrder(Orderedproduct);
        Console.WriteLine(Orderedproduct.State);
        //for Delivery
        DeliveryRobot RobotDisplay = new DeliveryRobot("cocacola is");
        Console.WriteLine(RobotDisplay.Name);
        RobotDisplay.ProcessOrder(Orderedproduct);
        Console.WriteLine(Orderedproduct.State);*/

        /* foreach (WarehouseRobot robotss in WarehouseRobot)
         {
             Console.WriteLine(robotss.Name);
             robotss.ProcessOrder(Orderedproduct);
             Console.WriteLine(Orderedproduct.State);
         }*/
        List<WarehouseRobot> WarehouseRobot = new List<WarehouseRobot>
        {
            new PackingRobot("Packing Robot"),
            new DispatchRobot("Dispatch Robot"),
            new DeliveryRobot("Delivery Robot")
        };
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the warehouse management. Choose one of the following:");
            Console.WriteLine("1. Add a new order");
            Console.WriteLine("2. Display Status of All Orders");
            Console.WriteLine("3. Process The Last Order by Each Robot");
            Console.WriteLine("4. Exit The Program");
            Console.Write("Choose an option: ");

            string? key = Console.ReadLine();

            switch (key)
            {
                case "1":
                    Console.Write("Enter product name: ");

                    string? productName = Console.ReadLine();
                    Product product = new Product(productName);
                    Order newOrder = new Order(product);
                    if (string.IsNullOrWhiteSpace(productName))
                    {
                        Console.WriteLine("Product name cannot be empty.");
                        break;
                    }
                    productorder.Add(newOrder);

                    Console.WriteLine("The New Order is added.");
                    break;

                case "2":
                    Console.WriteLine("\nThose are The List of all orders:");

                    if (productorder.Count == 0)
                    {
                        Console.WriteLine("There are no orders.");
                        break;
                    }

                    foreach (Order order in productorder)
                    {
                        Console.WriteLine(
                            $"Product: {order.OrderProduct.Name}, " +
                            $"Status: {order.State}"
                        );
                    }

                    break;

                case "3":
                    if (productorder.Count == 0)
                    {
                        Console.WriteLine("There are no orders.");
                        break;
                    }

                    // Get the last order
                    Order lastOrder = productorder[productorder.Count - 1];

                    Console.WriteLine(
                        $"\nProcessing last order: {lastOrder.OrderProduct.Name}"
                    );

                    // Process the order with every robot
                    foreach (WarehouseRobot robot in WarehouseRobot)
                    {
                        Console.WriteLine($"Robot: {robot.Name}");

                        robot.ProcessOrder(lastOrder);

                        Console.WriteLine($"Status: {lastOrder.State}");
                    }

                    break;

                case "4":
                    Console.WriteLine("Exiting the program...");
                    return;

                default:
                    Console.WriteLine("Try another Character");
                    break;

            }
        ;
        }


    }
    class Product
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    name = "Product Name";

                }
                else
                {
                    name = value;

                }

            }
        }

        public Product(string name1)
        {
            this.Name = name1;//this one calls set propporty
        }


    }
    class Order
    {
        private string state;
        public Order(Product OP)
        {
            OrderProduct = OP;
            this.state = "Ordered";
        }
        public Product OrderProduct
        {
            get;
            set;

        }
        public String State
        {
            get
            {
                return state;
            }
            set
            {
                if (value == "Ordered" || value == "Packed" || value == "Dispatched" || value == "Delivered")
                {
                    state = value;
                }
                else
                {
                    state = "Ordered";
                }
            }

        }

    }

    abstract class WarehouseRobot

    {
        private string name;
        public string Name
        {
            get;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    name = "Robot Name";
                }
                else
                {
                    name = value;
                }
            }
        }
        public WarehouseRobot(string name2)
        {
            this.Name = name2;
        }
        public abstract void ProcessOrder(Order o);

    }
    class PackingRobot : WarehouseRobot
    {
        public PackingRobot(string name) : base(name)
        {

        }
        public override void ProcessOrder(Order o)
        {
            o.State = "Packed";
        }
    }
    class DispatchRobot : WarehouseRobot
    {
        public DispatchRobot(string name) : base(name)
        {

        }
        public override void ProcessOrder(Order o)
        {
            o.State = "Dispatched";
        }
    }
    class DeliveryRobot : WarehouseRobot
    {
        public DeliveryRobot(string name) : base(name)
        {

        }
        public override void ProcessOrder(Order o)
        {
            o.State = "Delivered";
        }
    }
}