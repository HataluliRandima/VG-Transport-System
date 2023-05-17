import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import Layout from './components/shared/Layout'
//import Register from './pages/Register'
import Dashboard from './components/Dashboard'
 import Products from './components/Products'
import LoginC from './components/LoginC';
import RegisterC from './components/RegisterC';
import Navbar from './components/Navbar';
function App() {
  return (
     <div> 
      
       <Router>
            <Routes>
            <Route path="/" element={<Navbar/>} />
                <Route   element={<Layout />}>
                    <Route path="dashboard" element={<Dashboard />} />
                     <Route path="products" element={<Products />} />  
                </Route>
                {/* <Route path="/register" element={<Register />} /> */}
                <Route path="loginc" element={<LoginC />} />
                <Route path="/registerc" element={<RegisterC />} />
            </Routes>
        </Router>

     </div>
  );
}

export default App;
