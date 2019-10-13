import * as React from 'react';
import { actions, FlowChart, INodeInnerDefaultProps } from "@mrblenny/react-flow-chart";
import { cloneDeep, mapValues } from 'lodash';
import style from "./Flow.module.css"

const chartSimple = {
    offset: {
        x: 0,
        y: 0
    },

    nodes: {
        node1: {
            id: "node1",
            type: "output-only",
            position: {
                x: 300,
                y: 100
            },
            ports: {
                port1: {
                    id: "port1",
                    type: "output",
                    properties: {
                        value: "yes"
                    }
                },
                port2: {
                    id: "port2",
                    type: "output",
                    properties: {
                        value: "no"
                    }
                }
            }
        },
        node2: {
            id: "node2",
            type: "input-output",
            position: {
                x: 300,
                y: 300
            },
            ports: {
                port1: {
                    id: "port1",
                    type: "input"
                },
                port2: {
                    id: "port2",
                    type: "output"
                }
            }
        },
    },
    links: {
        link1: {
            id: "link1",
            from: {
                nodeId: "node1",
                portId: "port2"
            },
            to: {
                nodeId: "node2",
                portId: "port1"
            },
        },
    },
    selected: {},
    hovered: {}
};

/**
 * Create the custom component,
 * Make sure it has the same prop signature
 */
const NodeInnerCustom = ({ node, config }: INodeInnerDefaultProps) => {
    if (node.type === 'output-only') {
        return (
            <div className={style.outer}>
                <p>Use Node inner to customise the content of the node</p>
            </div>
        )
    } else {
        return (
            <div className={style.outer}>
                <p>Add custom displays for each node.type</p>
                <p>You may need to stop event propagation so your forms work.</p>
                <br />
                <input className={style.input}
                    type="text"
                    placeholder="Some Input"
                    onClick={(e) => e.stopPropagation()}
                    onMouseUp={(e) => e.stopPropagation()}
                    onMouseDown={(e) => e.stopPropagation()}
                />
            </div>
        )
    }
}

export class Flow extends React.Component {
    public state = cloneDeep(chartSimple)
    public render() {
        const chart = this.state
        const stateActions = mapValues(actions, (func: any) =>
            (...args: any) => this.setState(func(...args))) as typeof actions

        return ( 
                <FlowChart
                    chart={chart}
                    callbacks={stateActions}
                    Components={{
                        NodeInner: NodeInnerCustom,
                    }}
                /> 
        )
    }
}