import React from 'react';

const HomePageTabContent = ({formData,setFormData,titleHeader}) => {
    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevFormData => ({
            ...prevFormData,
            [name]: name === 'status' ? value === 'true' : value
        }));
    };

    const handleSubmit = () => {
        console.log('Form Data:', formData);
        // API'ye gönderme işlemi
        // fetch('/api/submit', { method: 'POST', body: JSON.stringify(formData) })
    };

    return <>
        <div className="tab-content">
            <h3 className="panel-website-icon">
                {titleHeader}
            </h3>
        <div className="panel-box-select">
            <span className="col-md-3">Title:</span>
            <div className="col-md-9">
                <input
                    type="text"
                    name="title"
                    value={formData.title}
                    onChange={handleChange}
                />
            </div>
        </div>
        <div className="panel-box-select">
            <span className="col-md-3">Subtitle:</span>
            <div className="col-md-9">
                <input
                    type="text"
                    name="subtitle"
                    value={formData.subtitle}
                    onChange={handleChange}
                />
            </div>
        </div>
        <div className="panel-box-select">
            <span className="col-md-3">Status:</span>
            <div className="col-md-9">
                <select
                    name="status"
                    value={formData.status}
                    onChange={handleChange}
                >
                    <option value="true">Show</option>
                    <option value="false">Hidden</option>
                </select>
            </div>
        </div>
        <div className="panel-box-select">
            <div className="col-md-3"></div>
            <div className="col-md-9 ps-2">
                <button
                    onClick={handleSubmit}
                    className="secondary-button panel-website-icon-show__button"
                >
                    Submit
                </button>
            </div>
        </div>
        </div>
    </>
};

export default HomePageTabContent;
