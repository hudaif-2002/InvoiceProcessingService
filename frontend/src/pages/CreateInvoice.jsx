import { useState } from "react";
import { useNavigate } from "react-router-dom";

import Navbar from "../components/Navbar";
import invoiceService from "../services/invoiceService";

function CreateInvoice() {

    const [customerName, setCustomerName] = useState("");

    const [amount, setAmount] = useState("");

    const navigate = useNavigate();

    const handleSubmit = async (e) => {

        e.preventDefault();

        try {

            await invoiceService.createInvoice({
                customerName,
                amount: Number(amount)
            });

            alert("Invoice Created");

            navigate("/invoices");

        } catch {

            alert("Failed to create invoice");
        }
    };

    return (
        <>
            <Navbar />

            <div className="container mt-5">

                <h2>Create Invoice</h2>

                <form onSubmit={handleSubmit}>

                    <div className="mb-3">

                        <label className="form-label">
                            Customer Name
                        </label>

                        <input
                            className="form-control"
                            value={customerName}
                            onChange={(e) =>
                                setCustomerName(
                                    e.target.value
                                )
                            }
                        />

                    </div>

                    <div className="mb-3">

                        <label className="form-label">
                            Amount
                        </label>

                        <input
                            type="number"
                            className="form-control"
                            value={amount}
                            onChange={(e) =>
                                setAmount(
                                    e.target.value
                                )
                            }
                        />

                    </div>

                    <button
                        className="btn btn-primary"
                        type="submit"
                    >
                        Create
                    </button>

                </form>

            </div>
        </>
    );
}

export default CreateInvoice;