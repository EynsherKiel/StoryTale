import * as React from 'react'; 
import { Flow } from './Graph/Flow';
import style from "./App.module.css"

const App: React.FC = () => (
    <div>
        <div className={style.box}>
            <div>
                <button>1</button>
            </div>
            <div>
                <button>2</button>
            </div>
            <div>
                <button>3</button>
            </div>
            <div>
                <button>4</button>
            </div>
            <div className={style.flow}>
                <Flow />
            </div>
        </div>

        <div className={style.r}>
            dsada
        </div>

    </div>
);

export default App;