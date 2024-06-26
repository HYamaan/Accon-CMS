import React from 'react';

const HomePageTabContentOneInput = ({formData,setFormData,titleHeader}) => {
    const handleChange = (e) => {
        const { name, value } = e.target;
      setFormData(value);
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
                <span className="col-md-3">Total Recent Posts:</span>
                <div className="col-md-9">
                    <input
                        type="text"
                        name="title"
                        value={formData}
                        onChange={handleChange}
                    />
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

export default HomePageTabContentOneInput;
