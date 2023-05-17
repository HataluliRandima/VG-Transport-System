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
function App() {
  return (
     <div> 
      
       <Router>
            <Routes>
            <Route path="/" element={<Navbar/>} />
                <Route   element={<Layout />}>
                    <Route path="dashboard" element={<Dashboard />} />
                     <Route path="packages" element={<Packages />} />  
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
            </Routes>
        </Router>

     </div>
  );
}

export default App;
