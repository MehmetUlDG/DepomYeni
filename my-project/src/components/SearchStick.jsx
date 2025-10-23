import { useState } from "react"

const SearchStick = ({aramaMetni,setAramaMetni}) => {
    return (
        <div className="arama-cubugu">
            <input
                type="text"
                placeholder="Başlığa göre ara..."
                value={aramaMetni}
                onChange={(e) => setAramaMetni(e.target.value)}
                aria-label="Kitap başlığı arama"
            />
        </div>
    )
}
export default SearchStick;