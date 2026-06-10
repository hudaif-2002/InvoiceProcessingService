import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from "./pages/Login"; 
import Register from "./pages/register";
import Dashboard from "./pages/Dashboard"
import InvoiceList from "./pages/InvoiceList";
import CreateInvoice from "./pages/CreateInvoice";
import ProtectedRoute from "./components/ProtectedRoute";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/register" element={<Register />} />
                <Route
                    path="/home"
                    element={
                        <ProtectedRoute>
                            <Dashboard />
                        </ProtectedRoute>
                    }
                />
                <Route path="/invoices" element={<ProtectedRoute>
                    <InvoiceList />
                </ProtectedRoute>} />

                <Route path="/create-invoice" element={<ProtectedRoute>
                    <CreateInvoice />
                    </ProtectedRoute>} />
            </Routes>
        </BrowserRouter>
    );
}
export default App;
                 
