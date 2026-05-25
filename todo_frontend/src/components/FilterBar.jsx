function FilterBar(props) {

    function handleCategoryChange(e) {
        if (e.target.value !== "") {
            props.onCategory(e.target.value);
        }
    }

    function handlePriorityChange(e) {
        if (e.target.value !== "") {
            props.onPriority(e.target.value);
        }
    }

    return (
        <div className="filter-box">
            <label>Category: </label>
            <select onChange={handleCategoryChange} defaultValue="">
                <option value="" disabled>Select</option>
                <option value="work">Work</option>
                <option value="personal">Personal</option>
            </select>

            <label> Priority: </label>
            <select onChange={handlePriorityChange} defaultValue="">
                <option value="" disabled>Select</option>
                <option value="low">Low</option>
                <option value="medium">Medium</option>
                <option value="high">High</option>
            </select>

            <button onClick={props.onReset}>Show All</button>
        </div>
    );
}

export default FilterBar;