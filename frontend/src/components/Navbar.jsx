import { Link, useNavigate } from "react-router-dom";

function Navbar() {

    const navigate = useNavigate();

    const logout = () => {

        localStorage.removeItem("token");

        navigate("/");
    };

    return (
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">

            <div className="container">

                <Link
                    className="navbar-brand"
                    to="/home"
                >
                    Invoice App
                </Link>

                <div className="navbar-nav">

                    <Link
                        className="nav-link"
                        to="/home"
                    >
                        Dashboard
                    </Link>

                    <Link
                        className="nav-link"
                        to="/invoices"
                    >
                        Invoices
                    </Link>

                    <Link
                        className="nav-link"
                        to="/create-invoice"
                    >
                        Create Invoice
                    </Link>

                    <button
                        className="btn btn-danger ms-3"
                        onClick={logout}
                    >
                        Logout
                    </button>

                </div>

            </div>

        </nav>
    );
}

export default Navbar;