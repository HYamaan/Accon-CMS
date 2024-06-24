import React from 'react';
import CountUp from 'react-countup';
import { useInView } from 'react-intersection-observer';

const CounterupArea = () => {
    const [ref, inView] = useInView({
        threshold: 0.1,
        triggerOnce: true
    });

    return (
            <div ref={ref} className="counterup-area" style={{backgroundImage: "url(counter_bg.jpg)"}}>
                <div className="bg-counterup"></div>
                <div className="container">
                    <div className="row">
                        <div className="col-md-3 col-sm-6 counter-border">
                            <div className="counter-item">
                                <h2 className="counter">
                                    {inView && <CountUp start={0} end={150} duration={2.75}/>}
                                </h2>
                                <h4>Working Persons</h4>
                            </div>
                        </div>
                        <div className="col-md-3 col-sm-6 counter-border">
                            <div className="counter-item">
                                <h2 className="counter">
                                    {inView && <CountUp start={0} end={1200} duration={2.75}/>}
                                </h2>
                                <h4>Projects Completed</h4>
                            </div>
                        </div>
                        <div className="col-md-3 col-sm-6 counter-border">
                            <div className="counter-item">
                                <h2 className="counter">
                                    {inView && <CountUp start={0} end={800} duration={2.75}/>}
                                </h2>
                                <h4>Happy Clients</h4>
                            </div>
                        </div>
                        <div className="col-md-3 col-sm-6 counter-border">
                            <div className="counter-item achieved">
                                <h2 className="counter">
                                    {inView && <CountUp start={0} end={1200} duration={2.75}/>}
                                </h2>
                                <h4>Awards Achieved</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    );
};

export default CounterupArea;
