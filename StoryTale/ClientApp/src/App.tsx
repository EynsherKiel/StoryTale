import * as React from 'react'; 
import {

    BrowserRouter as Router,
    Switch,
    Route,
    NavLink 
} from "react-router-dom";
import { Flow } from './Graph/Flow';
import style from "./App.module.css"

const App: React.FC = () => (
    <Router>
        <div className={style.wrapper}> 

            <header className={style.header}>
                <nav>
                    <ul>
                        <li>
                            <NavLink exact activeClassName={style.current} to="/">Home</NavLink>
                        </li>
                        <li>
                            <NavLink exact activeClassName={style.current} to="/about">About</NavLink>
                        </li>
                        <li>
                            <NavLink exact activeClassName={style.current} to="/dashboard">Dashboard</NavLink>
                        </li>
                    </ul>
                </nav>
            </header> 
                 
            <main className={style.main}>
                <Switch>
                    <Route exact path="/">
                        <Flow />
                    </Route>
                    <Route path="/about">
                    <div>
                        about
                    </div>
                    </Route>
                    <Route path="/dashboard">
                        <div>
                            dashboard
                        </div>
                    </Route>
                </Switch>
            </main>

            <footer className={style.footer}>Footer</footer>
        </div>
    </Router>
);

export default App;