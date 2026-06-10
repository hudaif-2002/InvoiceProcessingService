import { useEffect, useState } from "react";

import Navbar from "../components/Navbar";
import invoiceService from "../services/invoiceService";

function InvoiceList() {

    const [invoices, setInvoices] = useState([]);

    useEffect(() => {

        loadInvoices();

    }, []);

    const loadInvoices = async () => {

        try {

            const response =
                await invoiceService.getInvoices();

            setInvoices(response.data);

        } catch {

            alert("Failed to load invoices");
        }
    };

    return (
        <>
            <Navbar />

            <div className="container mt-5">

                <h2>Invoices</h2>

                <table className="table table-bordered">

                    <thead>

                        <tr>
                            <th>Id</th>
                            <th>Customer</th>
                            <th>Amount</th>
                        </tr>

                    </thead>

                    <tbody>

                        {invoices.map(invoice => (

                            <tr key={invoice.id}>

                                <td>{invoice.id}</td>

                                <td>
                                    {invoice.customerName}
                                </td>

                                <td>
                                    {invoice.amount}
                                </td>

                            </tr>

                        ))}

                    </tbody>

                </table>

            </div>
        </>
    );
}

export default InvoiceList;