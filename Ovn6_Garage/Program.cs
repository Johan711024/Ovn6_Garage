
using Ovn6_Garage;
using Ovn6_Garage.UserInterface;

IUI ui = new UI();
ui.Print($"Program executing");

var manager = new Manager();

manager.Run(ui);


ui.Print($"Program ended");

