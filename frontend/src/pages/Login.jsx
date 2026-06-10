import { useState } from "react";
import { useNavigate } from "react-router-dom";
import authService from "../services/authService";

function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            await authService.login({
                username,
                password
            });

            navigate("/home");
        }
        catch (error) {
            console.error(error);

            alert("Invalid username or password");
        }
    };

    return (
        <div className="container mt-5">
            <h2>Login</h2>

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
                    className="btn btn-success"
                >
                    Login
                </button>
            </form>
        </div>
    );
}

export default Login;