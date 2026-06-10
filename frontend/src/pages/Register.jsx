import { useState } from "react";
import authService from "../services/authService";

function Register() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            await authService.register({
                username,
                password
            });

            alert("User registered successfully");
        }
        catch (error) {
            console.error(error);

            alert("Registration failed");
        }
    };

    return (
        <div className="container mt-5">
            <h2>Register</h2>

            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label className="form-label">
                        Username
                    </label>

                    <input
                        type="text"
                        className="form-control"
                        value={username}
                        onChange={(e) =>
                            setUsername(e.target.value)
                        }
                    />
                </div>

                <div className="mb-3">
                    <label className="form-label">
                        Password
                    </label>

                    <input
                        type="password"
                        className="form-control"
                        value={password}
                        onChange={(e) =>
                            setPassword(e.target.value)
                        }
                    />
                </div>

                <button
                    type="submit"
                    className="btn btn-primary"
                >
                    Register
                </button>
            </form>
        </div>
    );
}

export default Register;