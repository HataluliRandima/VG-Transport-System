import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import Layout from './components/shared/Layout'
//import Register from './pages/Register'
import Dashboard from './components/Dashboard'
 //import Products from './components/Products'
import LoginC from './components/LoginC';
import RegisterC from './components/RegisterC';
import Navbar from './components/Navbar';
import LayoutAdmin from './components/shared/LayoutAdmin';
import DashboardAdmin from './components/pages/Admin/DashboardAdmin';
import Customers from './components/pages/Admin/Customers';
import Packages from './components/Packages';
import Bookings from './components/Bookings';
import LayoutDriver from './components/shared/LayoutDriver';
import DashboardDriver from './components/pages/Driver/DashboardDriver';
 import Tsetse from './components/pages/Admin/Tsetse';
import Tabletest from './components/pages/Customer/Tabletest';
import Messages from './components/Messages';
import Check from './Check';
 //import AddBooking from './AddBooking';

 

 const HelloList = <Tsetse />;
const HelloList22 = <Tsetse />;
 
const HelloList11 = <DashboardDriver />;

function App() {
  return (
     <div> 
      
       <Router>
            <Routes>
            <Route path="/" element={<Navbar/>} />
                <Route   element={<Layout />}>
                    <Route path="dashboard" element={<Dashboard />} />
                     <Route path="packages" element={<Packages 
                     title={"Tab Test"}
                     tabs={[
                      
                       { name: "Hello", content: HelloList },
                       
                       { name: "Hello 2", content: HelloList11 },
                     ]}
                     editable={true}
                      />} />  
                      <Route path="messages" element={<Messages 
                     title={"Bookings"}
                     tabs={[
                      
                       { name: "Add booking", content: HelloList },
                       
                       { name: "Hello 2", content: HelloList11 },
                       { name: "Hello 33", content: HelloList22 },
                     ]}
                      
                      />} /> 
                     <Route path="bookings" element={<Bookings />} />  
                </Route>
                {/* <Route path="/register" element={<Register />} /> */}
                <Route     element={<LayoutAdmin />}>
                    <Route path="dashadmin" element={<DashboardAdmin />} />
                     <Route path="customers" element={<Customers/>} />  
                </Route>
                <Route     element={<LayoutDriver />}>
                    <Route path="dashdriver" element={<DashboardDriver />} />
                     {/* <Route path="customers" element={<Customers/>} />   */}
                </Route>
                <Route path="loginc" element={<LoginC />} />
                <Route path="/registerc" element={<RegisterC />} />
                <Route path="/tab" element={<Tabletest />} />
                <Route path="/check" element={<Check />} />
            </Routes>
        </Router>

     </div>
  );
}

export default App;
