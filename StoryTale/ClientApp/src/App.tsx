import * as React from 'react'; 
import {

    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import { Flow } from './Graph/Flow';
import style from "./App.module.css"

const App: React.FC = () => (
    <Router>
        <div className={style.wrapper}> 

            <div className={style.header}> 
                <div>
                    <nav>
                        <ul>
                            <li>
                                <Link to="/">Home</Link>
                            </li>
                            <li>
                                <Link to="/about">About</Link>
                            </li>
                            <li>
                                <Link to="/dashboard">Dashboard</Link>
                            </li>
                        </ul>
                    </nav>
                </div> 
            </div> 
                 
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

            <div className={style.footer}><div >Footer</div></div>
        </div>
    </Router>
);

export default App;