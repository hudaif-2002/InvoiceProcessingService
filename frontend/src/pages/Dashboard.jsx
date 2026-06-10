import Navbar from "../components/Navbar";

function Dashboard() {

    return (
        <>
            <Navbar />

            <div className="container mt-5">

                <h2>Dashboard</h2>

                <div className="card p-4">

                    <h4>
                        Welcome to Invoice Processing System
                    </h4>

                    <p>
                        Use the navigation bar to manage invoices.
                    </p>

                </div>

            </div>
        </>
    );
}

export default Dashboard;