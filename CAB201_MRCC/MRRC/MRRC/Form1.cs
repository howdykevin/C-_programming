using MRRCManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MRRC
{//Kirsten
    public partial class Form1 : Form
    {
        // All Gloabl features used throughout the whole GUI.
        private CRM crm;
        private Fleet fleet;
        private List<Customer> customerCollection;
        private List<Vehicle> vehicleCollection;
        private string[] customerLayout = new string[] { };
        private List<Vehicle> rental;
        private int Customer;







        //Kirsten Moylan, n9948210
        public Form1() // This is the name of the GUI. <-- and it's opening function/method.
        {

            InitializeComponent();
            createRentalGrpBox.Visible = false;


        }
        //Kirsten Moylan, n9948210
        private void clearPreviousFigures() // This is a method which clears all previous figures that were contained in each datagrid.
        {
            vehicleDatagrid.Rows.Clear();
            customersDatagridView.Rows.Clear();
            rentalReportDataGrid.Rows.Clear();
            rentalSearchDatagrid.Rows.Clear();
        }
        //Kevin Gunawan, n9812482
        private void populatecustomerCombobox() // This like the method says populates the customer combobox - in tab 4,  with all customers who aren't renting a vehicle.
        {
            fleet = new Fleet();
            crm = new CRM();
            List<Customer> customer = new List<Customer>();
            customer = crm.GetCustomers();
            foreach (var item in customer)
            {
                if (fleet.IsRenting(item.CustomerID))
                {
                    continue;
                }
                customerList.Items.Add(item.CustomerID + "." + item.Title + item.FirstNames + item.LastNames);
            }
        }
        //Kirsten Moylan, n9948210
        private void customerDataGrid() // This is a function that as the title says populates the customer datagrid, based on the customer CSV file.
        {
            crm = new CRM();
            int itemInList = 0;
            crm.LoadFromFile();
            customerCollection = crm.GetCustomers();
            foreach (var item in customerCollection)
            {
                customersDatagridView.Rows.Add(customerCollection[itemInList].CustomerID, customerCollection[itemInList].Title, customerCollection[itemInList].FirstNames, customerCollection[itemInList].LastNames, customerCollection[itemInList].Gen, customerCollection[itemInList].DateOfBirth);
                itemInList++;
            }
            populatecustomerCombobox();

        }
        //Kirsten Moylan, n9948210
        private void fleetDataGrid() // This method puts the data from the fleet.csv and adds it to the vehicle data grid.
        {
            int itemList = 0;
            fleet = new Fleet();
            fleet.LoadFromFile();
            vehicleCollection = fleet.GetFleet();
            foreach (var item in vehicleCollection)
            {
                vehicleDatagrid.Rows.Add(vehicleCollection[itemList].VehicleRego, vehicleCollection[itemList].Make, vehicleCollection[itemList].Model, vehicleCollection[itemList].Year, vehicleCollection[itemList].VehicleClas, vehicleCollection[itemList].NumSeats, vehicleCollection[itemList].Trans, vehicleCollection[itemList].Fuelz, vehicleCollection[itemList].GPS1, vehicleCollection[itemList].SunRoof, vehicleCollection[itemList].DailyRate, vehicleCollection[itemList].Colour);
                itemList++;
            }

        }
        //Kirsten Moylan, n9948210
        private void rentalLayout() // This method puts the data from the rental.csv and puts it in the datagrid view in tab 3. However this method also grabs the fleets.csv in order to get the daily cost of the car being rented.
        {
            int itemList = 0;
            fleet = new Fleet();
            fleet.LoadFromFile();
            rental = fleet.GetFleet(true);
            foreach (var item in rental)
            {
                Customer = fleet.RentedBy(rental[itemList].VehicleRego);
                rentalReportDataGrid.Rows.Add(rental[itemList].VehicleRego, Customer, rental[itemList].DailyRate);
                itemList++;
            }

            
        }
        //Kirsten Moylan, n9948210
        private void groupDefaults() // This sets each text box for adding/ modifying vehicle to their default state - being blank.
        {
            regoTxtbox.Text = String.Empty;
            makeTxtbox.Text = String.Empty;
            modelTxtbox.Text = String.Empty;
            yearTxtbox.Text = String.Empty;
            colourTxtbox.Text = String.Empty;
            carClassInput.SelectedIndex = -1;
            transmissionTypeInput.SelectedIndex = -1;
            fuelTypeInput.SelectedIndex = -1;
            sunroofCheckbox.Checked = false;
            gpsCheckbox.Checked = false;
            numOfSeatsInput.Value = 0;
            dailyRateInput.Value = 0;



        }
        //Kirsten Moylan, n9948210
        private void customerDefaults() // This sets the textboxes and other input material to their default state for the customer groupbox (default being blank).
        {
            customerID.Text = string.Empty;
            custTitle.Text = string.Empty; ;
            firstNme.Text = string.Empty; ;
            lastNme.Text = string.Empty; ;
            Gender.SelectedIndex = -1;
            DOB.Value = DOB.MaxDate;

        }
        //Kirsten Moylan, n9948210
        private void customerEnabled() //This sets all the customer input methods to their default enabled state - which is true.
        {
            customerID.Enabled = true;
            custTitle.Enabled = true;
            firstNme.Enabled = true;
            lastNme.Enabled = true;
            Gender.Enabled = true;
            DOB.Enabled = true;
        }

        //Kirsten Moylan, n9948210
        private void defaultEnabled() //This sets all the vehicle input methods to their default enabled state - which is true.
        {
            regoTxtbox.Enabled = true;
            makeTxtbox.Enabled = true;
            modelTxtbox.Enabled = true;
            yearTxtbox.Enabled = true;
            colourTxtbox.Enabled = true;
            carClassInput.Enabled = true;
            transmissionTypeInput.Enabled = true;
            fuelTypeInput.Enabled = true;
            sunroofCheckbox.Enabled = true;
            gpsCheckbox.Enabled = true;
            numOfSeatsInput.Enabled = true;
            dailyRateInput.Enabled = true;
        }


        //Kirsten Moylan, n9948210
        private void Form1_Load(object sender, EventArgs e) //This loads the app (so opens it).
        {
            fleetDataGrid();
            customerDataGrid();
            rentalLayout();
            search.Enabled = false;
            createRentalGrpBox.Enabled = false;
        }

        //Kirsten Moylan, n9948210
        private void tabMenu_SelectedIndexChanged(object sender, EventArgs e) // this method is setting what the default visibility is depending on which tab is clicked in the app.
        {
            if (tabMenu.SelectedIndex == 0)
            {
                vehicleGrpbox.Visible = false;
                createRentalGrpBox.Visible = false;
                groupBox4.Visible = true;
                groupBox4.Text = "Modify Fleet";
                customerGrpbox.Visible = false;
                groupBox6.Visible = false;


            }
            else if (tabMenu.SelectedIndex == 1)
            {
                vehicleGrpbox.Visible = false;
                createRentalGrpBox.Visible = false;
                groupBox4.Visible = true;
                groupBox4.Text = "Modify CRM";
                customerGrpbox.Visible = false;
                groupBox6.Visible = false;


            }
            else if (tabMenu.SelectedIndex == 2)
            {
                vehicleGrpbox.Visible = false;
                createRentalGrpBox.Visible = false;
                groupBox4.Visible = false;
                groupBox4.Text = "Modify Rentals";
                customerGrpbox.Visible = false;
                groupBox6.Visible = true;

            }

            else if (tabMenu.SelectedIndex == 3)
            {
                vehicleGrpbox.Visible = false;
                createRentalGrpBox.Visible = true;
                groupBox4.Visible = false;
                customerGrpbox.Visible = false;
                rentalSearchDatagrid.Rows.Clear();
                groupBox6.Visible = false;
                createRentalGrpBox.Enabled = false;


            }
        }



        //Kirsten Moylan, n9948210
        private void modifyBtn_Click(object sender, EventArgs e) // This method allows the user to edit one of the existing vehicles or customers in the csv, by clicking this button. 
                                                                 // When the button is clicked the program reads the selected line and seperates it into cells than moves those cells to the corresponding input material.
        {
            if (tabMenu.SelectedIndex == 0)
            {
                vehicleGrpbox.Text = "Modify Vehicle";
                if (fleet.IsRented(vehicleDatagrid.SelectedRows[0].Cells[0].Value.ToString())) // This is an error which appears if the user tries to modify a vehicle which is currently being rented.
                {
                    MessageBox.Show("Cannot Modify Car that is being rented","Modify Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    vehicleGrpbox.Visible = false;
                }
                else if (vehicleDatagrid.SelectedRows.Count > 0) // this is if it goes through.
                {
                    vehicleGrpbox.Visible = true;
                    regoTxtbox.ReadOnly = true;
                    regoTxtbox.Text = vehicleDatagrid.SelectedRows[0].Cells[0].Value.ToString();
                    makeTxtbox.Text = vehicleDatagrid.SelectedRows[0].Cells[1].Value.ToString();
                    modelTxtbox.Text = vehicleDatagrid.SelectedRows[0].Cells[2].Value.ToString();
                    carClassInput.Text = vehicleDatagrid.SelectedRows[0].Cells[4].Value.ToString();
                    yearTxtbox.Text = vehicleDatagrid.SelectedRows[0].Cells[3].Value.ToString();
                    transmissionTypeInput.Text = vehicleDatagrid.SelectedRows[0].Cells[6].Value.ToString();
                    fuelTypeInput.Text = vehicleDatagrid.SelectedRows[0].Cells[7].Value.ToString();
                    int numseatsConvert = int.Parse(vehicleDatagrid.SelectedRows[0].Cells[5].Value.ToString());
                    numOfSeatsInput.Value = numseatsConvert;
                    string checkBoolean = vehicleDatagrid.SelectedRows[0].Cells[8].Value.ToString().ToLower();
                    if (checkBoolean == "true")
                    {
                        gpsCheckbox.Checked = true;
                    }
                    else if (checkBoolean == "false")
                    {
                        gpsCheckbox.Checked = false;
                    }

                    string checkBool2 = vehicleDatagrid.SelectedRows[0].Cells[9].Value.ToString().ToLower();
                    if (checkBool2 == "true")
                    {
                        sunroofCheckbox.Checked = true;
                    }
                    else if (checkBool2 == "false")
                    {
                        sunroofCheckbox.Checked = false;
                    }


                    decimal dailyRateConversion = decimal.Parse(vehicleDatagrid.SelectedRows[0].Cells[10].Value.ToString());
                    dailyRateInput.Value = dailyRateConversion;
                    colourTxtbox.Text = vehicleDatagrid.SelectedRows[0].Cells[11].Value.ToString();

                }
                else // this error will never appear due to a row always being selected... but we did it as a just in case.
                {
                    MessageBox.Show("Please Select a row to modify", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            else if (tabMenu.SelectedIndex == 1) // this is the modify function for the customers.
            {
                customerDefaults();
                customerEnabled();
                customerGrpbox.Text = "Modify Customer";
                if (fleet.IsRenting(int.Parse(customersDatagridView.SelectedRows[0].Cells[0].Value.ToString()))) // same as before - this is the error message that will appear if the user tries to modify a customer who is renting a vehicle.
                {
                    MessageBox.Show("Cannot modify a customer who is renting a vehicle", "Modify Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (customersDatagridView.SelectedRows.Count > 0) // this is the normal modift customer which makes it seperate it into cells then put it in the corresponding input method (e.g. textbox, dropdownbox, etc.)
                {
                    customerGrpbox.Visible = true;
                    customerID.Enabled = false;
                    customerID.Text = customersDatagridView.SelectedRows[0].Cells[0].Value.ToString();
                    custTitle.Text = customersDatagridView.SelectedRows[0].Cells[1].Value.ToString();
                    firstNme.Text = customersDatagridView.SelectedRows[0].Cells[2].Value.ToString();
                    lastNme.Text = customersDatagridView.SelectedRows[0].Cells[3].Value.ToString();
                    Gender.Text = customersDatagridView.SelectedRows[0].Cells[4].Value.ToString();
                    DOB.Text = customersDatagridView.SelectedRows[0].Cells[5].Value.ToString();

                }
                else
                {
                    MessageBox.Show("Can't Modify an unselected Row","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }


        }
        //Kirsten Moylan, n9948210
        private void addBtn_Click(object sender, EventArgs e) // This is the add button for both the customers and the vehicles.
                                                              //when this button appears it just makes everything visible in the groupbox holding all the input methods.
        {
            if (tabMenu.SelectedIndex == 0)
            {
                vehicleGrpbox.Visible = true;
                customerGrpbox.Visible = false;
                groupDefaults();
                defaultEnabled();
                vehicleGrpbox.Text = "Add Vehicle";
                regoTxtbox.ReadOnly = false;


                if (regoTxtbox.Text == "" && makeTxtbox.Text == "" && modelTxtbox.Text == "" && yearTxtbox.Text == "" && carClassInput.SelectedIndex == -1) //this tells the program that the submit button must not be visible until all required fields are filled out.
                {
                    vehicleSubmitBtn.Enabled = false;

                }
            }
            else if (tabMenu.SelectedIndex == 1) // this is the customer add button.
            {
                customerDefaults();
                customerEnabled();
                vehicleGrpbox.Visible = false;
                customerGrpbox.Visible = true;
                customerGrpbox.Text = "Add Customer";

            }



        }
        //Kirsten Moylan, n9948210
        private void vehicleSubmitBtn_Click(object sender, EventArgs e)  // This is the submit button for the vehicle input. This submit button can either confirm a new entry - "Add Vehicle", or submit the changes or non-changes of a modify vehicle.
        {
            int doubleUps = 0;
            int currentYear = 2018;
            int yearConversion = int.Parse(yearTxtbox.Text);

            if (vehicleGrpbox.Text == "Add Vehicle") // This first part determines if we are in the adding vehicle section. then this method adds all of the input methods into the datagrid view but also saves it to the files csv.
            {
                foreach (DataGridViewRow item in vehicleDatagrid.Rows)
                {
                    if (regoTxtbox.Text == item.Cells[0].Value as string)
                    {
                        doubleUps++;
                    }

                }
                if (numOfSeatsInput.Value == 0) // the following sets the default if the customer decides to delete certain boxes and make them empty.
                {
                    numOfSeatsInput.Value = 4;
                }
                if (colourTxtbox.Text == string.Empty || colourTxtbox.Text == " ")
                {
                    colourTxtbox.Text = "Black";
                }
                if (dailyRateInput.Value < 40)
                {
                    if (carClassInput.SelectedIndex == 0)
                    {
                        dailyRateInput.Value = 50;
                    }
                    else if (carClassInput.SelectedIndex == 1)
                    {
                        dailyRateInput.Value = 80;
                    }
                    else if (carClassInput.SelectedIndex == 2)
                    {
                        dailyRateInput.Value = 120;
                    }
                    else if (carClassInput.SelectedIndex == 3)
                    {
                        dailyRateInput.Value = 130;
                    }
                }

                if (doubleUps >= 1) // this checks to make sure that there is no double ups with the vehicle rego shown above in the foreach loop.
                {
                    MessageBox.Show("Cannot Add this Vehicle, Vehicle Rego Already Exists!", "Vehicle Rego Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (yearTxtbox.TextLength < 4) // this error message occurs if the user doesn't enter a 4 digit year.
                {
                    MessageBox.Show("Year cannot be less than 4 digits", "Production Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (yearConversion > currentYear) // This error appears if the user enters a year that is higher than the current year (2018)
                {
                    MessageBox.Show("Cannot have a vehicle from the future.","Year",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if (regoTxtbox.TextLength < 6) // This error appears if the user enters a vehicle rego that is less than 6 (accepted) values.
                {
                    MessageBox.Show("Vehicle Registration cannot be less that 6 values.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else // This adds it if none of the above errors occur.
                {
                    vehicleDatagrid.Rows.Add(regoTxtbox.Text.ToUpper(), makeTxtbox.Text, modelTxtbox.Text, yearTxtbox.Text, carClassInput.Text, numOfSeatsInput.Value, transmissionTypeInput.Text, fuelTypeInput.Text, gpsCheckbox.CheckState, sunroofCheckbox.CheckState, dailyRateInput.Value, colourTxtbox.Text);
                    int yearConvert = int.Parse(yearTxtbox.Text);
                    int seatConversion = int.Parse(numOfSeatsInput.Value.ToString());
                    double dailyRateConversion = double.Parse(dailyRateInput.Value.ToString());
                    bool sunroofConvert = Convert.ToBoolean(sunroofCheckbox.CheckState);
                    bool gpsConvert = Convert.ToBoolean(gpsCheckbox.CheckState);
                    VehicleClass carClass = (VehicleClass)Enum.Parse(typeof(VehicleClass), carClassInput.Text);
                    TransmissionType transmission = (TransmissionType)Enum.Parse(typeof(TransmissionType), transmissionTypeInput.Text);
                    FuelType fuel = (FuelType)Enum.Parse(typeof(FuelType), fuelTypeInput.Text);
                    Vehicle newVehicle = new Vehicle(regoTxtbox.Text.ToUpper(), carClass, makeTxtbox.Text, modelTxtbox.Text, yearConvert, seatConversion, transmission, fuel, sunroofConvert, gpsConvert, dailyRateConversion, colourTxtbox.Text);
                    fleet.AddVehicle(newVehicle);
                    fleet.SaveToFile();
                    crm.SaveToFile();
                }








            }
            else if (vehicleGrpbox.Text == "Modify Vehicle") // This is when the submit button is cliked when the user is modifying a vehicle.
                // So the program first updates the csv by deleting the edited item then adding it back in as the updated one. then it updates the app.
            {
                fleet.RemoveVehicle(vehicleDatagrid.SelectedRows[0].Cells[0].Value.ToString());
                int txtboxToYear = int.Parse(yearTxtbox.Text);
                int seatConvert = int.Parse(numOfSeatsInput.Value.ToString());
                double dailyRateConvert = double.Parse(dailyRateInput.Value.ToString());
                bool sunroofBool = Convert.ToBoolean(sunroofCheckbox.CheckState);
                bool gpsBool = Convert.ToBoolean(gpsCheckbox.CheckState);
                VehicleClass carClass = (VehicleClass)Enum.Parse(typeof(VehicleClass), carClassInput.Text);
                TransmissionType transmission = (TransmissionType)Enum.Parse(typeof(TransmissionType), transmissionTypeInput.Text);
                FuelType fuel = (FuelType)Enum.Parse(typeof(FuelType), fuelTypeInput.Text);
                Vehicle mdfVehicle = new Vehicle(regoTxtbox.Text.ToUpper(), carClass, makeTxtbox.Text, modelTxtbox.Text, txtboxToYear, seatConvert, transmission, fuel, sunroofBool, gpsBool, dailyRateConvert, colourTxtbox.Text);
                fleet.AddVehicle(mdfVehicle);
                fleet.SaveToFile();
                crm.SaveToFile();
                DataGridViewRow update = vehicleDatagrid.SelectedRows[0];
                update.Cells[0].Value = regoTxtbox.Text;
                update.Cells[1].Value = makeTxtbox.Text;
                update.Cells[2].Value = modelTxtbox.Text;
                update.Cells[3].Value = yearTxtbox.Text;
                update.Cells[4].Value = carClassInput.Text;
                update.Cells[5].Value = numOfSeatsInput.Value;
                update.Cells[6].Value = transmissionTypeInput.Text;
                update.Cells[7].Value = fuelTypeInput.Text;
                update.Cells[8].Value = gpsCheckbox.Checked;
                update.Cells[9].Value = sunroofCheckbox.Checked;
                update.Cells[10].Value = dailyRateInput.Value;
                update.Cells[11].Value = colourTxtbox.Text;
                

            }
        


            vehicleGrpbox.Visible = false; 




        }
        //Kirsten Moylan, n9948210
        private void vehicleCancelBtn_Click(object sender, EventArgs e) // This is when the vehicle button is clicked, it will return the user to the screen they were on before.
        {
            groupDefaults();
            defaultEnabled();

        }
        //Kirsten Moylan, n9948210
        private void removeBtn_Click(object sender, EventArgs e) // This is when the remove button is clicked for both the customer and fleet tabs.
        {
            vehicleGrpbox.Visible = false;
            
            if (tabMenu.SelectedIndex == 0) // this is for vehicles
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); // this makes sure the user wantes to remove it
                if (result == DialogResult.Yes) // then if yes is clicked it will remove it as long as it is not currently being rented
                {

                    if (fleet.IsRented(vehicleDatagrid.SelectedRows[0].Cells["Column1"].Value.ToString())) // this message appears if the vehicle is currently being rented.
                    {
                        MessageBox.Show("Cannot remove item which is currently being rented.", "Vehicle remove Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        fleet.RemoveVehicle(vehicleDatagrid.SelectedRows[0].Cells[0].Value.ToString());
                        fleet.SaveToFile();
                        vehicleDatagrid.Rows.RemoveAt(vehicleDatagrid.SelectedRows[0].Index);
                        crm.SaveToFile();
                    }


                }
                else if (result == DialogResult.No) // if no is clicked it goes back to the original screen the user was on.
                {
                    
                }
            }
            else if (tabMenu.SelectedIndex == 1) // this is for customers
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); // same process as before when they say remove they will be prompted to make sure they are sure.
                if (result == DialogResult.Yes) // If they click yes it will either go through or return an error message - if the customer is renting a vehicle.
                {
                    int custID2bool = int.Parse(customersDatagridView.SelectedRows[0].Cells["Column13"].Value.ToString());

                    if (fleet.IsRenting(custID2bool))
                    {
                        MessageBox.Show("Cannot Remove Customer Who is renting a Vehicle", "Removal Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    }
                    else
                    {
                        int rmvCus = int.Parse(customersDatagridView.SelectedRows[0].Cells[0].Value.ToString());
                        crm.RemoveCustomer(rmvCus, fleet);
                        fleet.SaveToFile();
                        crm.SaveToFile();
                        customersDatagridView.Rows.RemoveAt(customersDatagridView.SelectedRows[0].Index);
                        


                    }



                }
                else if (result == DialogResult.No) // If no is clicked it returns the customer to the original screen they were on.
                {

                }

            }

        }

        //Kirsten Moylan, n9948210
        private void regoTxtbox_TextChanged(object sender, EventArgs e) // This is a method to see if the rego is the last required field to be filled in, in order for the submit button to appear.
        {
            if (regoTxtbox.Text != "" && makeTxtbox.Text != "" && modelTxtbox.Text != "" && yearTxtbox.Text != "" && carClassInput.SelectedIndex != -1)
            {
                vehicleSubmitBtn.Enabled = true;

            }


        }
        //Kirsten Moylan, n9948210
        private void vehicleCancelBtn_Click_1(object sender, EventArgs e) // This is the vehicle cancel button which makes the add or modify vehicle groupbox to dissappar / clear.
        {
            vehicleGrpbox.Visible = false;

        }
        //Kirsten Moylan, n9948210
        private void makeTxtbox_TextChanged(object sender, EventArgs e) // This is a method to see if the make is the last required field to be filled in, in order for the submit button to appear.
        {
            if (regoTxtbox.Text != "" && makeTxtbox.Text != "" && modelTxtbox.Text != "" && yearTxtbox.Text != "" && carClassInput.SelectedIndex != -1)
            {
                vehicleSubmitBtn.Enabled = true;

            }
        }
        //Kirsten Moylan, n9948210
        private void modelTxtbox_TextChanged(object sender, EventArgs e) // This is a method to see if the model is the last required field to be filled in, in order for the submit button to appear.
        {
            if (regoTxtbox.Text != "" && makeTxtbox.Text != "" && modelTxtbox.Text != "" && yearTxtbox.Text != "" && carClassInput.SelectedIndex != -1)
            {
                vehicleSubmitBtn.Enabled = true;

            }
        }
        //Kirsten Moylan, n9948210
        private void carClassInput_SelectedIndexChanged(object sender, EventArgs e) // This is a method to see if the car class is the last required field to be filled in, in order for the submit button to appear.
        {
            defaultEnabled();

            if (regoTxtbox.Text != "" && makeTxtbox.Text != "" && modelTxtbox.Text != "" && yearTxtbox.Text != "" && carClassInput.SelectedIndex != -1)
            {
                vehicleSubmitBtn.Enabled = true;

            }

            // however this method also auto fills out all non-required fields when a user selects one of the following options.
            // Some of the non required fields will be uneditable whereas others the user will be able to edit.
            if (carClassInput.SelectedIndex == 0) //economy
            {


                transmissionTypeInput.SelectedIndex = 0;
                transmissionTypeInput.Enabled = false;
                dailyRateInput.Value = 50;
                dailyRateInput.Enabled = false;
                colourTxtbox.Text = "Black";
                sunroofCheckbox.Checked = false;
                gpsCheckbox.Checked = false;
                numOfSeatsInput.Value = 4;
                fuelTypeInput.SelectedIndex = 0;

            }

            else if (carClassInput.SelectedIndex == 1) // family
            {

                transmissionTypeInput.SelectedIndex = 0;
                dailyRateInput.Value = 80;
                dailyRateInput.Enabled = false;
                colourTxtbox.Text = "Black";
                sunroofCheckbox.Checked = false;
                gpsCheckbox.Checked = false;
                numOfSeatsInput.Value = 4;
                fuelTypeInput.SelectedIndex = 0;



            }

            else if (carClassInput.SelectedIndex == 2) // luxury
            {

                transmissionTypeInput.SelectedIndex = 0;
                dailyRateInput.Value = 120;
                dailyRateInput.Enabled = false;
                colourTxtbox.Text = "Black";
                sunroofCheckbox.Checked = true;
                sunroofCheckbox.Enabled = false;
                gpsCheckbox.Checked = true;
                gpsCheckbox.Enabled = false;
                numOfSeatsInput.Value = 4;
                fuelTypeInput.SelectedIndex = 0;



            }
            else if (carClassInput.SelectedIndex == 3) //commercial
            {

                transmissionTypeInput.SelectedIndex = 0;
                dailyRateInput.Value = 130;
                dailyRateInput.Enabled = false;
                colourTxtbox.Text = "Black";
                sunroofCheckbox.Checked = false;
                gpsCheckbox.Checked = false;
                numOfSeatsInput.Value = 4;
                fuelTypeInput.SelectedIndex = 1;
                fuelTypeInput.Enabled = false;



            }
        }
        //Kirsten Moylan, n9948210
        private void yearTxtbox_TextChanged(object sender, EventArgs e) // This is a method to see if the rego is the last required field to be filled in, in order for the submit button to appear.
            //However this method also checks if the user is inputing number as if they are not an error message will appear notifying them to enter numeric values only.
        {


            try
            {
                if (char.IsNumber(yearTxtbox.Text, 0) && char.IsNumber(yearTxtbox.Text, 1) && char.IsNumber(yearTxtbox.Text, 2)
                    && char.IsNumber(yearTxtbox.Text, 3))
                {

                }

                else
                {
                    MessageBox.Show("Please enter a numeric year.","Input Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    yearTxtbox.Text = String.Empty;

                }
            }
            catch
            {
            }

            if (regoTxtbox.Text != "" && makeTxtbox.Text != "" && modelTxtbox.Text != "" && yearTxtbox.Text != "" && carClassInput.SelectedIndex != -1)
            {
                vehicleSubmitBtn.Enabled = true;

            }

        }
        //Kirsten Moylan, n9948210
        private void regoTxtbox_KeyUp(object sender, KeyEventArgs e) // This methid checks if the user is adhering to the guidelines of the assumption that rego must be 3 letters followed by three numbers.
            //And if they are not adhering to this a error message will appear telling them to add 3 numbers followed by three letters and make them rewrite there registration again.
        {


            try
            {
                if (char.IsLetter(regoTxtbox.Text, 0))
                {
                    MessageBox.Show("Rego must be 3 numbers followed by 3 letters", "Rego input error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    regoTxtbox.Text = string.Empty;
                }
                else if (char.IsLetter(regoTxtbox.Text, 1))
                {
                    MessageBox.Show("Rego must be 3 numbers followed by 3 letters", "Rego input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    regoTxtbox.Text = string.Empty;
                }
                else if (char.IsLetter(regoTxtbox.Text, 2))
                {
                    MessageBox.Show("Rego must be 3 numbers followed by 3 letters", "Rego input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    regoTxtbox.Text = string.Empty;
                }
                else if (char.IsNumber(regoTxtbox.Text, 3))
                {
                    MessageBox.Show("Rego must be 3 numbers followed by 3 letters", "Rego input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    regoTxtbox.Text = string.Empty;
                }
                else if (char.IsNumber(regoTxtbox.Text, 4))
                {
                    MessageBox.Show("Rego must be 3 numbers followed by 3 letters", "Rego input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    regoTxtbox.Text = string.Empty;
                }
                else if (char.IsNumber(regoTxtbox.Text, 5))
                {
                    MessageBox.Show("Rego must be 3 numbers followed by 3 letters", "Rego input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    regoTxtbox.Text = string.Empty;
                }

            }
            catch
            {

            }


        }
        //Kirsten Moylan, n9948210
        private void customerID_TextChanged(object sender, EventArgs e) // This method checks if the customer ID is the last item that needs to be enteredby the user, in order for the submit button to appear.
            
        {
            if (customerID.Text != "" && custTitle.Text != "" && firstNme.Text != "" && lastNme.Text != "" && Gender.SelectedIndex != -1)
            {
                custSubmitBtn.Enabled = true;
            }
            //Along with this it is checking that the input of the customer ID is valid (an int) otherwise it will return an error message and make the customer enter there ID again.
            try
            {
                if (char.IsLetter(customerID.Text, 0))
                {
                    MessageBox.Show("Customer ID must be numeric","Input Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    customerID.Text = string.Empty;
                }
                else if (char.IsLetter(customerID.Text, 1))
                {
                    MessageBox.Show("Customer ID must be numeric", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerID.Text = string.Empty;
                }
                else if (char.IsLetter(customerID.Text, 2))
                {
                    MessageBox.Show("Customer ID must be numeric", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerID.Text = string.Empty;
                }
                else if (char.IsLetter(customerID.Text, 3))
                {
                    MessageBox.Show("Customer ID must be numeric", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerID.Text = string.Empty;
                }
                else if (char.IsLetter(customerID.Text, 4))
                {
                    MessageBox.Show("Customer ID must be numeric", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerID.Text = string.Empty;
                }
                else if (char.IsLetter(customerID.Text, 5))
                {
                    MessageBox.Show("Customer ID must be numeric", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerID.Text = string.Empty;
                }
            }
            catch
            {

            }

        }
        //Kirsten Moylan, n9948210
        private void custCancelBtn_Click(object sender, EventArgs e) // This is the customer cancel button. when this is clicked it removes the groupbox displayed.
        {
            vehicleGrpbox.Visible = false;
            customerGrpbox.Visible = false;
        }
        //Kirsten Moylan, n9948210
        private void custSubmitBtn_Click(object sender, EventArgs e) // This is the customer submit button. like the vehicle submit button it all depends on whether the user is adding or modifying a vehicle.
        {
            if (customerGrpbox.Text == "Add Customer") // This is if add customer is occuring when the submit button is clicked.
            {
                int doubleUps = 0;
                foreach (DataGridViewRow item in customersDatagridView.Rows) // This then checks to see if the ID already exists.
                {

                    if (customerID.Text == item.Cells[0].Value.ToString())
                    {
                        doubleUps++;
                    }

                }
                if (doubleUps > 0) // then this error message occurs if it finds the ID already exists
                {
                    MessageBox.Show("This customer ID already exists!", "Cannot Add Customer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerDefaults();
                    customerEnabled();
                    customerGrpbox.Visible = false;
                    vehicleGrpbox.Visible = false;
                }
                else if (customerID.Text == " " || custTitle.Text == " " || firstNme.Text == " " || lastNme.Text == " " || Gender.SelectedIndex == -1) // This tests to see if the user didn't enter anything into an input box other than a space.
                {
                    MessageBox.Show("All fields must be entered!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerGrpbox.Visible = false;
                    vehicleGrpbox.Visible = false;
                }
                else // This just adds it to the Customer CSV then to the actual datagrid.
                {
                    
                    int idParse = int.Parse(customerID.Text);
                    Gender Gen = (Gender)Enum.Parse(typeof(Gender), Gender.Text);
                    Customer adCust = new Customer(idParse, custTitle.Text, firstNme.Text, lastNme.Text, Gen, DOB.Value.ToString("dd/MM/yyyy"));
                    customersDatagridView.Rows.Add(customerID.Text, custTitle.Text, firstNme.Text, lastNme.Text, Gender.Text, DOB.Value.ToString("dd/MM/yyyy"));
                    crm.AddCustomer(adCust);
                    crm.SaveToFile();

                    customerDefaults();
                    customerEnabled();
                    customerGrpbox.Visible = false;
                    vehicleGrpbox.Visible = false;
                }
                
            }
            else if (customerGrpbox.Text == "Modify Customer") // This is if the user is modifying a customer and clicks submit.
                //
            {
                if (customerID.Text == " " || custTitle.Text == " " || firstNme.Text == " " || lastNme.Text == " " || Gender.SelectedIndex == -1) // This tests to see if the user didn't enter anything into an input box other than a space.
                {
                    MessageBox.Show("All fields must be entered!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    customerGrpbox.Visible = false;
                    vehicleGrpbox.Visible = false;
                }
                else // This is if no errors occured.
                {
                    crm.RemoveCustomer(int.Parse(customersDatagridView.SelectedRows[0].Cells[0].Value.ToString()), fleet);
                    int idParse = int.Parse(customerID.Text);
                    Gender Gen = (Gender)Enum.Parse(typeof(Gender), Gender.Text);
                    Customer adCust = new Customer(idParse, custTitle.Text, firstNme.Text, lastNme.Text, Gen, DOB.Value.ToString("dd/MM/yyyy"));
                    crm.AddCustomer(adCust);
                    fleet.SaveToFile();
                    crm.SaveToFile();
                    DataGridViewRow update = customersDatagridView.SelectedRows[0];
                    update.Cells[0].Value = customerID.Text;
                    update.Cells[1].Value = custTitle.Text;
                    update.Cells[2].Value = firstNme.Text;
                    update.Cells[3].Value = lastNme.Text;
                    update.Cells[4].Value = Gender.Text;
                    update.Cells[5].Value = DOB.Value.ToString("dd/MM/yyyy");
                }
                

                customerDefaults();
                customerEnabled();
                customerGrpbox.Visible = false;
                vehicleGrpbox.Visible = false;

            }

        }
        //Kirsten Moylan, n9948210
        private void custTitle_TextChanged(object sender, EventArgs e) // This method checks if the customer title is the last item that needs to be enteredby the user, in order for the submit button to appear.
        {
            if (customerID.Text != "" && custTitle.Text != "" && firstNme.Text != "" && lastNme.Text != "" && Gender.SelectedIndex != -1)
            {
                custSubmitBtn.Enabled = true;
            }
        }
        //Kirsten Moylan, n9948210
        private void firstNme_TextChanged(object sender, EventArgs e) // This method checks if the customers first name is the last item that needs to be enteredby the user, in order for the submit button to appear.
        {
            if (customerID.Text != "" && custTitle.Text != "" && firstNme.Text != "" && lastNme.Text != "" && Gender.SelectedIndex != -1)
            {
                custSubmitBtn.Enabled = true;
            }
        }
        //Kirsten Moylan, n9948210
        private void lastNme_TextChanged(object sender, EventArgs e) // This method checks if the customers last name is the last item that needs to be enteredby the user, in order for the submit button to appear.
        {
            if (customerID.Text != "" && custTitle.Text != "" && firstNme.Text != "" && lastNme.Text != "" && Gender.SelectedIndex != -1)
            {
                custSubmitBtn.Enabled = true;
            }
        }
        //Kirsten Moylan, n9948210
        private void Gender_SelectedIndexChanged(object sender, EventArgs e) // This method checks if the customers gender is the last item that needs to be enteredby the user, in order for the submit button to appear.
        {
            if (customerID.Text != "" && custTitle.Text != "" && firstNme.Text != "" && lastNme.Text != "" && Gender.SelectedIndex != -1)
            {
                custSubmitBtn.Enabled = true;
            }
        }

        //Kirsten Moylan, n9948210
        private void DOB_ValueChanged(object sender, EventArgs e) // This checks that all required fields have been filled out so the submit button can appear.
        {
            if (customerID.Text != "" && custTitle.Text != "" && firstNme.Text != "" && lastNme.Text != "" && Gender.SelectedIndex != -1)
            {
                custSubmitBtn.Enabled = true;
            }
            
            
        }

        //Kirsten Moylan, n9948210
        private void returnVehicleBtn_Click(object sender, EventArgs e) //This is the return vehicle button. when this button is clicked it asks the user if they are sure they want to return the rented vehicle.
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to remove this Rental?", "Rental Return", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) // If they click yes it returns the vehicle.
            {
                fleet.ReturnCar(rentalReportDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                fleet.SaveToFile();
                crm.SaveToFile();
                rentalReportDataGrid.Rows.RemoveAt(rentalReportDataGrid.SelectedRows[0].Index);
                

            }
            else // if they click no it goes back to the original screen they were on.
            {

            }


        }
        //Kirsten Moylan, n9948210
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e) // This saves everything to the corressponding csv's when the app is closed.
        {
            fleet.SaveToFile();
            crm.SaveToFile();


        }

        //Kevin Gunawan, n9812482
        private void search_Click(object sender, EventArgs e) // This is when the search button is clicked it will read the query in the textbox and refer back to our query where the output will be displayed in the datagrid view - with the corresponding correct outputs.
        {
            rent_button.Enabled = false;
            createRentalGrpBox.Enabled = true;
            query.Enabled = true;
            Min.Enabled = true;
            Max.Enabled = true;
            int itemList = 0;
            fleet = new Fleet();
            rentalSearchDatagrid.Rows.Clear();
            List<Vehicle> result = fleet.AndOrQuery(query.Text);
            foreach (var item in result)
            {
                rentalSearchDatagrid.Rows.Add(result[itemList].VehicleRego, result[itemList].Make, result[itemList].Model, result[itemList].Year, result[itemList].VehicleClas, result[itemList].NumSeats, result[itemList].Trans, result[itemList].Fuelz, result[itemList].GPS1, result[itemList].SunRoof, result[itemList].Colour, result[itemList].DailyRate);
                itemList++;
            }
            query.Text = string.Empty;
            Min.Value = 0;
            Max.Value = 0;

        }

        //Kevin Gunawan, n9812482
        private void query_TextChanged(object sender, EventArgs e) // We decided for ours we didn't want to allow the user to edit the min and max when they write a query.
            //So this method shows when any key or change occurs in the query it disables the min max blocks. Along with ensuring an input has been put in otherwise the search button wont appear.
        {
            Min.Enabled = false;
            Max.Enabled = false;
            search.Enabled = true;
            if (String.IsNullOrWhiteSpace(query.Text))
            {
                search.Enabled = false;
                Showall.Enabled = true;
            }
            else
            {
                search.Enabled = true;
                Showall.Enabled = false;
            }
        }

        //Kevin Gunawan, n9812482
        private void Showall_Click(object sender, EventArgs e) // This is when the showall button is clicked, there is three possible outcomes to this.
        {
            rent_button.Enabled = false;
            createRentalGrpBox.Enabled = true;
            int itemList = 0;
            fleet = new Fleet();
            rentalSearchDatagrid.Rows.Clear();
            List<Vehicle> result = new List<Vehicle>();
            if (Min.Value >= 1 && Max.Value >= Min.Value) // This is if the min and max value has been entered it displays the output corresponding to that.
            {
                result = fleet.CostRange((int)Min.Value, (int)Max.Value);
            }
            else if (Min.Value == 0 && Max.Value == 0) // This is if the user leaves min and max as their origninal value it shows all items in the fleet csv.
            {
                result = fleet.Any();
            }

            foreach (var item in result) // This is the process of adding it to the datagrid.
            {
                rentalSearchDatagrid.Rows.Add(result[itemList].VehicleRego, result[itemList].Make, result[itemList].Model, result[itemList].Year, result[itemList].VehicleClas, result[itemList].NumSeats, result[itemList].Trans, result[itemList].Fuelz, result[itemList].GPS1, result[itemList].SunRoof, result[itemList].Colour, result[itemList].DailyRate);
                itemList++;
            }

            query.Text = string.Empty;
            Min.Value = 0;
            Max.Value = 0;
            Min.Enabled = true;
            Max.Enabled = true;
            query.Enabled = true;
        }

        //Kevin Gunawan, n9812482
        private void Min_ValueChanged(object sender, EventArgs e) // This disables the query box if anything happens in the min updown box.
        {

            query.Enabled = false;
        }
        //Kevin Gunawan, n9812482
        private void Max_ValueChanged(object sender, EventArgs e) // This disables the query box if anything happens in the max updown box.
        {

            query.Enabled = false;
        }
        //Kevin Gunawan, n9812482
        private void rent_button_Click(object sender, EventArgs e) // If the rent button is clicked it will take the customer ID, the vehicle rego and the daily price of the vehicle, then add this to the rental report / the rental csv.
        {

            string[] item = customerList.SelectedItem.ToString().Split('.');
            string id = item[0];
            string rego = rentalSearchDatagrid.SelectedRows[0].Cells[0].Value.ToString();
            string dailyrate = rentalSearchDatagrid.SelectedRows[0].Cells[11].Value.ToString();
            rentalReportDataGrid.Rows.Add(rego, id, dailyrate);
            fleet.RentCar(rego, int.Parse(id));
            fleet.SaveToFile();
            crm.SaveToFile();
            createRentalGrpBox.Enabled = false;
            customerList.SelectedIndex = -1;
            rentalSearchDatagrid.Rows.Clear();
        }

        //Kevin Gunawan, n9812482
        private void customerList_SelectedIndexChanged(object sender, EventArgs e) // This is when the customer combobox value changes. It checks if the value is not null and if it is not null the rent value is able to be displayed.
        {
            
            if (customerList.SelectedIndex != -1 && rentalSearchDatagrid.Rows != null)
            {
                rent_button.Enabled = true;
            }
            int dailyRate = int.Parse(rentalSearchDatagrid.SelectedRows[0].Cells[11].Value.ToString());
            Total_cost.Text = "Total cost is " + dailyRate * rentalDuration.Value;


        }

        //Kevin Gunawan, n9812482
        private void rentalDuration_ValueChanged(object sender, EventArgs e) // This is the rental duration up down box when the value changes it will change the total cost label<-- by change i mean update.
        {
            int dailyRate = int.Parse(rentalSearchDatagrid.SelectedRows[0].Cells[11].Value.ToString());
            Total_cost.Text = "Total cost is " + dailyRate * rentalDuration.Value;
        }

        //Kevin Gunawan, n9812482
        private void rentalSearchDatagrid_CellClick(object sender, DataGridViewCellEventArgs e) // This is when the user clicks on a different cell in the datagrid it will update the total cost label.
        {
            int dailyRate = int.Parse(rentalSearchDatagrid.SelectedRows[0].Cells[11].Value.ToString());
            Total_cost.Text = "Total cost is " + dailyRate * rentalDuration.Value;
        }


    }
}


//Things that need to be fixed: - kevins part when rent is clicked make everything go clear.
// Add comments to everything
//label work .. who did what 
// test it all for word document thing
// Add in the completeness word document the parts we all did just as an extra.