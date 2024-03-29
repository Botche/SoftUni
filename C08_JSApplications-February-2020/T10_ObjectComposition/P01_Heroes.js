function solve() {
    function mage(name) {
        let mage = {
            name: name,
            health: 100,
            mana: 100,
        }

        return Object.assign(mage, canCast(mage));
    }

    function fighter(name) {
        let fighter = {
            name: name,
            health: 100,
            stamina: 100
        }

        return Object.assign(fighter, canFight(fighter));
    }

    const canFight = (state) => ({

        fight: () => {
            console.log(`${state.name} slashes at the foe!`);
            state.stamina--;
        }
    })

    const canCast = (state) => ({

        cast: (spellName) => {
            console.log(`${state.name} cast ${spellName}`);
            state.mana--;
        }
    })

    return {
        mage,
        fighter
    }
}


let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);
